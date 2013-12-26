using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AngelView.Core.Interfaces;
using System.Drawing;
using AngelView.Core.Components;

namespace AngelView.Core.Models
{
    public class FolderBranch : BranchElement, IFileData, IFolder
    {
        #region Fields
        protected string _folder;
        protected DirectoryInfo dirInfo;
        protected LeafElement loadedChild = null;
        #endregion

        #region Constructors
        public FolderBranch(IBranch Parent, string FolderName)
            : base(Parent)
        {
            _folder = FolderName;
            _LoadState = LoadState.PendingLoad;

            dirInfo = new DirectoryInfo(FolderName);
            if (Parent is DriveBranch)
            {
                _type = "Logical Drive";
            }
            else
            {
                _type = "Folder";
            }
        }
        public FolderBranch(FolderBranch child)
            : base(null)
        {
            _elementList = new List<ILeaf>();
            _LoadState = LoadState.PendingLoad;

            dirInfo = child.GetParentDirectoryInfo;
            _caption = dirInfo.Name;
            _folder = dirInfo.FullName;
            _type = "Folder";

            loadedChild = child;
            Load();
        }
        #endregion

        #region Methods
        private void LoadFiles()
        {
            string[] files;
            if (TryGetFiles(out files))
            {
                foreach (var file in files)
                {
                    if (LeafFactory.ShouldIncludeFile(file))
                    {
                        if (loadedChild == null)
                        {
                            _elementList.Add(LeafFactory.CreateFileLeaf(this, file));
                        }
                        else
                        {
                            // *** TODO ***
                            // Add preloaded child
                        }
                    }
                }
            }
        }
        private void LoadDirectories()
        {
            string[] directories;
            if (TryGetSubFolders(out directories))
            {
                foreach (var Dir in directories)
                {
                    if (LeafFactory.ShouldIncludeFolder(Dir))
                    {
                        AddFolder(Dir);
                    }
                }
            }
        }
        private void AddFolder(string folder)
        {
            ILeaf item = null;

            if (loadedChild != null)
            {
                if (loadedChild is FolderBranch)
                {
                    FolderBranch branch = loadedChild as FolderBranch;
                    if (branch.Folder == folder)
                    {
                        item = loadedChild;
                    }
                }
            }

            if (item == null)
            {
                item = LeafFactory.CreateBranchFromFolder(this, folder);
            }
            _elementList.Add(item);
        }
        private Boolean TryGetSubFolders(out string[] directories)
        {
            try
            {
                directories = Directory.GetDirectories(_folder, "*");
            }
            catch (DirectoryNotFoundException)
            {
                directories = null;
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                directories = null;
                return false;
            }
            return true;
        }
        private Boolean TryGetFiles(out string[] files)
        {
            try
            {
                files = Directory.GetFiles(_folder, "*");
            }
            catch (DirectoryNotFoundException)
            {
                files = null;
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                files = null;
                return false;
            }
            catch (FileNotFoundException)
            {
                files = null;
                return false;
            }
            return true;
        }

        public override void Load()
        {
            if (_LoadState == LoadState.Loaded) return;
            _LoadState = LoadState.Loaded;

            LoadDirectories();
            LoadFiles();
            Sort(false);
        }
        public override long Compare(ILeaf leaf1, ILeaf leaf2)
        {
            if ((leaf1 is IFolder) && (!(leaf2 is IFolder))) return -1;
            if ((leaf2 is IFolder) && (!(leaf1 is IFolder))) return 1;
            return base.Compare(leaf1, leaf2);
        }

        public void SortByDate(bool decending)
        {
            if (_elementList.Count == 0) return;

            int at = 0;
            bool directionSet;
            long res;
            ILeaf swapper;
            IFileData fileData1;
            IFileData fileData2;

            while ((at > -1) && (at < _elementList.Count))
            {
                directionSet = false;
                if (at < _elementList.Count - 1)
                {
                    res = Compare(_elementList[at], _elementList[at + 1]);

                    fileData1 = _elementList[at] as IFileData;
                    fileData2 = _elementList[at + 1] as IFileData;

                    if ((fileData1 != null) && (fileData2 != null))
                    {
                        res = fileData1.Date.Ticks - fileData2.Date.Ticks;
                    }

                    if (!decending) res = res * -1;
                    if (res < 0)
                    {
                        swapper = _elementList[at];
                        _elementList[at] = _elementList[at + 1];
                        _elementList[at + 1] = swapper;
                    }
                }

                if (at >= 1)
                {
                    res = Compare(_elementList[at], _elementList[at - 1]);

                    fileData1 = _elementList[at] as IFileData;
                    fileData2 = _elementList[at - 1] as IFileData;

                    if ((fileData1 != null) && (fileData2 != null))
                    {
                        res = fileData1.Date.Ticks - fileData2.Date.Ticks;
                    }

                    if (!decending) res = res * -1;
                    if (res > 0)
                    {
                        swapper = _elementList[at];
                        _elementList[at] = _elementList[at - 1];
                        _elementList[at - 1] = swapper;
                        at--;
                        directionSet = true;
                    }
                }

                if (!directionSet)
                {
                    at++;
                }
            }
        }

        #endregion

        #region Properties
        public override Color BackgroundColor
        {
            get
            {
                return Color.FromArgb(0xFFF4BF);
            }
        }
        public override string Caption
        {
            get
            {
                return dirInfo.Name;
            }
        }
        public DateTime Date
        {
            get { return dirInfo.LastWriteTime; }
        }
        public string Extension
        {
            get { return ""; }
        }
        public DirectoryInfo GetParentDirectoryInfo
        {
            get { return dirInfo.Parent; }
        }
        public string Folder
        {
            get { return _folder; }
        }
        public Int64 Size
        {
            get { return 0; }
        }
        #endregion
    }

}
