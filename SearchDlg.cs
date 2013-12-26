using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngelView.Core.Components;
using LPLTools.FindFile;

namespace AngelView.WinForms
{
    public partial class SearchDlg : Form
    {
    
        public SearchDlg()
        {
            InitializeComponent();
        }

        private void BrowseFolderBtn_Click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = folderBox.Text;
            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                folderBox.Text = folderDialog.SelectedPath;
            }
        }
        private void BuildControllerFromForm(ref SearchController searchController)
        {
            searchController.FileMask = maskBox.Text;
            searchController.Folder = folderBox.Text;
            searchController.SearchSubs = subFolders.Checked;
            searchController.SizeOptions.Options = (SearchOptions)sizeCondition.SelectedIndex;
            searchController.SizeOptions.Multiplier = (SizeMultiplier)sizeMultiplier.SelectedIndex;
            searchController.SizeOptions.Value = Convert.ToInt64(sizeValue.Text);
            searchController.DateOptions.Options = (SearchOptions)dateCondition.SelectedIndex;
            searchController.DateOptions.Date = dateValue.Value;
        }
        private void BuildFormFromController(SearchController searchController)
        {
            maskBox.Text = searchController.FileMask;
            folderBox.Text = searchController.Folder;
            subFolders.Checked = searchController.SearchSubs;
            sizeCondition.SelectedIndex = Convert.ToInt32(searchController.SizeOptions.Options);
            sizeValue.Text = searchController.SizeOptions.Value.ToString();
            sizeMultiplier.SelectedIndex = Convert.ToInt32(searchController.SizeOptions.Multiplier);
            dateCondition.SelectedIndex = Convert.ToInt32(searchController.DateOptions.Options);
            dateValue.Value = searchController.DateOptions.Date;
        }

        public bool Execute(ref SearchController searchController)
        {
            BuildFormFromController(searchController);
            bool result = ShowDialog() == DialogResult.OK;
            if (result)
            {
                BuildControllerFromForm(ref searchController);
            }
            return result;
        }
    }
}
