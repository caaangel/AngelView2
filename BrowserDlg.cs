using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AngelView.Core.Models;
using AngelView.Core.Components;
using AngelView.Core.Interfaces;
using LPLTools.FindFile;

namespace AngelView.WinForms
{
    public partial class BrowserDlg : Form
    {
        #region Fields
        private SearchController searchController = new SearchController();
        public ElementController Controller;
        public ViewerDlg viewer = new ViewerDlg();
        public SearchDlg searchDlg = new SearchDlg();
        #endregion

        #region Private
        private static string GetImageLeafDimensions(ILeaf leaf)
        {
            string dimensions = "";
            if (leaf == null) return dimensions;

            IImageLeaf imgLeaf = leaf as IImageLeaf;
            if (imgLeaf != null)
            {
                if (leaf.IsLoaded == LoadState.Loaded)
                {
                    dimensions = imgLeaf.Width.ToString() + 'x' + imgLeaf.Height.ToString();
                }
            }
            return dimensions;
        }
        private static ListViewItem LeafToListViewItem(ILeaf leaf)
        {
            ListViewItem item = new ListViewItem();

            item.Text = leaf.Caption;
            item.Tag = leaf;
            item.BackColor = leaf.BackgroundColor;
            item.ForeColor = leaf.FontColor;
            item.SubItems.Add(leaf.Type);

            IFileData filedata = leaf as IFileData;
            if (filedata != null)
            {
                item.SubItems.Add(filedata.Size.ToString());
                item.SubItems.Add(filedata.Date.ToShortDateString());
                item.SubItems.Add(GetImageLeafDimensions(leaf));
            }
            return item;
        }
        private bool OpenSearchDialog()
        {
            IFolder folderBranch = Controller.SelectedElement as IFolder;
            if (folderBranch != null)
            {
                searchController.Folder = folderBranch.Folder;
            }
            return searchDlg.Execute(ref searchController);
        }
        private List<FileInfo> SearchForFiles()
        {
            FindFile findFile = new FindFile(OnNewFolder, null);
            return findFile.Search(searchController);
        }
        private void SelectDefaultListViewItem()
        {
            SelectListViewItem(listView1.Items[0]);
        }
        private void SelectListViewItem(ListViewItem item)
        {
            item.Selected = true;
            item.Focused = true;
            listView1.EnsureVisible(item.Index);
            listView1.Select();
        }
        private void SetAddressBarText(IBranch branch)
        {
            if (branch is IFolder)
            {
                adressBox.Text = (branch as IFolder).Folder;
            }
            else
            {
                adressBox.Text = branch.Caption;
            }
        }
        private void SetDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }
        private void SetWaitCursor()
        {
            this.Cursor = Cursors.WaitCursor;
        }
        private void UpdateStatusLabel(string status)
        {
            statusLabel.Text = status;
            Application.DoEvents();
        }

        // Main functionality methods
        private void OpenSelectedBranch()
        {
            if (listView1.SelectedItems.Count == 0) return;

            IBranch item = listView1.SelectedItems[0].Tag as IBranch;
            if (item == null) return;

            Controller.SelectedElement = item;
        }
        private void BuildListView(IBranch branch)
        {
            listView1.Items.Clear();
            if (branch == null) return;

            OnBeginLoading(null, null);

            SetAddressBarText(branch);
            UpdateStatusLabel("Loading List ...");
            for (int i = 0; i < branch.Count; i++)
            {
                ListViewItem item = LeafToListViewItem(branch[i]);
                listView1.Items.Add(item);
                if (branch.SelectedIndex == i)
                {
                    SelectListViewItem(item);
                }
                //if ((i % 10) == 0)
                //{
                //    UpdateStatusLabel("Loading List ... " + i.ToString() + " / " + branch.Count.ToString());
                //}
            }
            if ((listView1.SelectedItems.Count == 0) &&
                (listView1.Items.Count > 0))
            {
                SelectDefaultListViewItem();
            }
            statusLabel.Text = listView1.Items.Count.ToString() + " items";

            OnEndLoading(null, null);
        }
        private void StartSearch()
        {
            if (!OpenSearchDialog()) return;
            SetWaitCursor();
            UpdateStatusLabel("Searching ...");
            List<FileInfo> files = SearchForFiles();
            UpdateStatusLabel("Building List ...");

            FileSearchBranch branch = new FileSearchBranch();
            int count = 0;
            foreach (var file in files)
            {
                ILeaf leaf = LeafFactory.CreateFileLeaf(branch, file);
                branch.Add(leaf);
                count++;
                UpdateStatusLabel("Building List ... " + count.ToString() + " / " + files.Count.ToString());
            }
            UpdateStatusLabel("Sorting List ... ");
//            branch.Sort(false);

            UpdateStatusLabel("Assigning To Controller ...");
            Controller.SelectedElement = branch;
            SetDefaultCursor();
        }
        private void OpenSelectedItem()
        {
            if (listView1.SelectedItems.Count == 0) return;
            IImageLeaf leaf = listView1.SelectedItems[0].Tag as IImageLeaf;
            if (leaf != null)
            {
                viewer.Execute(ref Controller);
                BuildListView(Controller.SelectedElement);
            }
            else
            {
                OpenSelectedBranch();
            }
        }
        #endregion

        #region Public
        public BrowserDlg()
        {
            InitializeComponent();
        }
        public void OnBeginLoading(object sender, LoadingElementArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
        }
        public void OnEndLoading(object sender, LoadingElementArgs e)
        {
            this.Cursor = Cursors.Default;
            Application.DoEvents();
        }
        public void OnNewFolder(object sender, NewStatusEventArgs e)
        {
            statusLabel.Text = "Searching " + e.Status;
            Application.DoEvents();
        }
        public void OnSelectedChange(object sender, SelectedElementChangeEventArgs e)
        {
            IBranch branch = e.Selected;
            if (branch == null) return;
            BuildListView(branch);
        }
        #endregion

        #region WinForms Events
        private void adressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Directory.Exists(adressBox.Text)) return;
                DirectoryInfo dirInfo = new DirectoryInfo(adressBox.Text);

                Controller.SelectedElement = LeafFactory.CreateBranchFromFolder(dirInfo.FullName) as IBranch;
            }
        }
        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.SelectedElement.Sort(false);
            BuildListView(Controller.SelectedElement);
        }
        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.SelectedElement.Sort(true);
            BuildListView(Controller.SelectedElement);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedItem();
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Controller == null) return;

            if (e.KeyCode == Keys.Back)
            {
                Controller.SelectParent();
            }
            if (e.KeyCode == Keys.Enter)
            {
                OpenSelectedItem();
            }
            if ((e.KeyCode == Keys.PageDown) &&
                (e.Control))
            {
                Controller.SelectParent(ParentSelection.Next);
            }
            if ((e.KeyCode == Keys.PageUp) &&
                (e.Control))
            {
                Controller.SelectParent(ParentSelection.Previous);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller == null) return;

            var index = listView1.SelectedIndices;
            if (index.Count == 0) return;

            Controller.SelectedElement.SelectedIndex = index[0];
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Controller = new ElementController("", OnSelectedChange, OnBeginLoading, OnEndLoading);
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSearch();
        }
        #endregion

        private void ascendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IFolder folder = Controller.SelectedElement as IFolder;

            if (folder != null)
            {
                folder.SortByDate(false);
                BuildListView(Controller.SelectedElement);
            }
        }

        private void decendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFolder folder = Controller.SelectedElement as IFolder;

            if (folder != null)
            {
                folder.SortByDate(true);
                BuildListView(Controller.SelectedElement);
            }
        }

    }
}
