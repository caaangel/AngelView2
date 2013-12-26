using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngelView.Core.Models;
using AngelView.Core.Interfaces;

namespace AngelView.Core.Components
{
    public enum ParentSelection
    {
        Actual,
        First,
        Last,
        Next,
        Previous,
        Random
    }

    public class SelectedElementChangeEventArgs : System.EventArgs
    {
        public SelectedElementChangeEventArgs(IBranch selectedElement)
        {
            Selected = selectedElement;
        }

        public IBranch Selected { get; set; }
    }
    public class LoadingElementArgs : System.EventArgs
    {
        public LoadingElementArgs(IBranch loadingElementBranch)
        {
            LoadingElementBranch = loadingElementBranch;
        }
    
        public IBranch LoadingElementBranch { get; set; }
    }

    public class ElementController
    {
        #region Fields
        private IBranch elements;
        private IBranch _activeElement;
        private Random random = new Random();
        #endregion

        #region Events
        public event EventHandler<SelectedElementChangeEventArgs> OnSelected;
        public event EventHandler<LoadingElementArgs> OnBeginLoading;
        public event EventHandler<LoadingElementArgs> OnEndLoading;
        #endregion

        #region Constructors
        public ElementController(string startUpFolder)
            : this(startUpFolder, null, null, null)
        {
        }
        public ElementController(string startUpFolder, EventHandler<SelectedElementChangeEventArgs> OnSelectedChanged) 
            : this(startUpFolder, OnSelectedChanged, null, null)
        {
        }
        public ElementController(string startUpFolder,
                                 EventHandler<SelectedElementChangeEventArgs> OnSelectedChanged,
                                 EventHandler<LoadingElementArgs> onBeginLoading,
                                 EventHandler<LoadingElementArgs> onEndLoading)
        {
            OnSelected = OnSelectedChanged;
            OnBeginLoading = onBeginLoading;
            OnEndLoading = onEndLoading;
            BuildAndSelectRootBranch(startUpFolder);
        }
        #endregion

        #region Properties
        public IBranch SelectedElement
        {
            get { return _activeElement; }
            set
            {
                if (_activeElement != null)
                {
                    _activeElement.Unload();
                    GC.Collect(2);
                }
                _activeElement = value;
                if (_activeElement.IsLoaded != LoadState.Loaded)
                {
                    DoOnBeginLoading(_activeElement);
                    _activeElement.Load();
                    DoOnEndLoading(_activeElement);
                }
                DoOnSelected();
            }
        }
        #endregion

        #region Methods
        private void BuildAndSelectRootBranch(string startUpFolder)
        {
            if (startUpFolder == "")
            {
                elements = LeafFactory.CreateDriveBranch();
            }
            else
            {
                elements = LeafFactory.CreateBranchFromFolder(startUpFolder);
            }

            SelectedElement = elements;
        }
        private IBranch BuildParentBranch()
        {
            IBranch newRoot;
            // Load parent if it isn't loaded
            FolderBranch branch = SelectedElement as FolderBranch;
            if (branch == null) return null;
            if (branch.GetParentDirectoryInfo == null)
            {
                // *** TODO ***
                return null;
            }
            else
            {
                newRoot = new FolderBranch(branch) as IBranch;
                return newRoot;
            }
        }
        private void DoOnBeginLoading(IBranch element)
        {
            if (OnBeginLoading != null)
            {
                OnBeginLoading(this, new LoadingElementArgs(element));
            }
        }
        private void DoOnEndLoading(IBranch element)
        {
            if (OnEndLoading != null)
            {
                OnEndLoading(this, new LoadingElementArgs(element));
            }
        }
        private void DoOnSelected()
        {
            if (OnSelected != null)
            {
                OnSelected(this, new SelectedElementChangeEventArgs(_activeElement));
            }
        }
        private void SetFirstParent(IBranch branch)
        {
            if (branch.Count == 0) return;
            SelectedElement = branch[0] as IBranch;
        }
        private void SetLastParent(IBranch branch)
        {
            if (branch.Count == 0) return;
            SelectedElement = branch[branch.Count - 1] as IBranch;
        }
        private void SetNextParent(IBranch branch, ref int index)
        {
            if (index == -1) return;
            index++;
            if (index >= branch.Count) return;
            SelectedElement = branch[index] as IBranch;
        }
        private void SetPreviousParent(IBranch branch, ref int index)
        {
            index--;
            if (index < 0) return;
            SelectedElement = branch[index] as IBranch;
        }
        private void SetRandomParent(IBranch branch)
        {
            SelectedElement = branch[random.Next(branch.Count)] as IBranch;
        }
        private void SetParentChild(ParentSelection parentSelection)
        {
            if (SelectedElement == null) return;
            if (SelectedElement is DriveBranch) return;

            IBranch branch = SelectedElement.Parent;

            if (branch == null)
            {
                branch = BuildParentBranch();
                if (branch == null) return;
            }
            int index = branch.IndexOf(SelectedElement);

            switch (parentSelection)
            {
                case ParentSelection.Actual:
                    SelectedElement = branch as IBranch;
                    break;
                case ParentSelection.Random:
                    SetRandomParent(branch);
                    break;
                case ParentSelection.Next:
                    SetNextParent(branch, ref index);
                    break;
                case ParentSelection.Previous:
                    SetPreviousParent(branch, ref index);
                    break;
                case ParentSelection.First:
                    SetFirstParent(branch);
                    break;
                case ParentSelection.Last:
                    SetLastParent(branch);
                    break;
            }
        }

        public void SelectParent()
        {
            SetParentChild(ParentSelection.Actual);
        }
        public void SelectParent(ParentSelection selection)
        {
            SetParentChild(selection);
        }
        #endregion
    }
}
