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
using AngelView.Core.Interfaces;
using LPLTools.FullScreen;

namespace AngelView.WinForms
{
    public partial class ViewerDlg : Form
    {
        #region Fields
        private ElementController Controller;
        private List<IImageLeaf> imgList = new List<IImageLeaf>();
        private int SelectedIndex = -1;
        private int ParentSelectedIndex = -1;
        private int ParentCount = -1;
        private Random random = new Random();
        private IFullScreen fullScreen;
        #endregion

        #region Private
        private void BuildImageListFromSelectedElement()
        {
            ResetImageList();
            if (Controller.SelectedElement == null) return;

            imgList = Controller.SelectedElement.GetList<IImageLeaf>();
            InitSelectedIndex();
        }
        private void DeterminePictureMode(int h, int w)
        {
            if ((h > picture.Height) ||
                (w > picture.Width))
            {
                picture.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        private string GetDimensionsText()
        {
            if (picture.Image != null)
            {
                string percent = "";
                if ((picture.Width < picture.Image.Width) ||
                    (picture.Height < picture.Image.Height))
                {
                    double perWidth = ((double) picture.Width / (double) picture.Image.Width) * (double)100;
                    double perHeight = ((double) picture.Height / (double) picture.Image.Height) * (double)100;
                    if ((perWidth < 100) ||
                        (perHeight < 100))
                    {
                        if (perWidth < perHeight)
                        {
                            percent = perWidth.ToString("0");
                        }
                        else
                        {
                            percent = perHeight.ToString("0");
                        }
                    }
                    percent = "[" + percent + "%]";
                }
                return picture.Image.Width.ToString() + 'x' + picture.Image.Height.ToString() + "   " + percent;
            }
            return "";
        }
        private static string GetFileDataText(ILeaf leaf)
        {
            string fileDataText = "";
            IFileData fileDataLeaf = leaf as IFileData;
            if (fileDataLeaf != null)
            {
                fileDataText = fileDataLeaf.Size.ToString("#,0") + "   |   " +
                               fileDataLeaf.Date.ToString("d MMM yyyy") + "   |   " +
                               fileDataLeaf.Extension;
            }
            return fileDataText;
        }
        private Image GetImage(ILeaf leaf)
        {
            IImageLeaf imgLeaf = leaf as IImageLeaf;
            if (imgLeaf != null)
            {
                return imgLeaf.Image;
            }
            return null;
        }
        private string GetSelectedIndexiesText()
        {
            if ((ParentSelectedIndex == -1) && (ParentCount == -1))
            {
                return String.Format("{0}/{1}",
                                     SelectedIndex + 1,
                                     imgList.Count);
            }
            return String.Format("{0}/{1} [{2}/{3}]",
                                 SelectedIndex + 1,
                                 imgList.Count,
                                 ParentSelectedIndex,
                                 ParentCount);
        }
        private void GetSelectedIndexFromController()
        {
            ILeaf leaf = Controller.SelectedElement[Controller.SelectedElement.SelectedIndex];
            if (leaf is IImageLeaf)
            {
                IImageLeaf imgLeaf = leaf as IImageLeaf;
                SelectedIndex = imgList.IndexOf(imgLeaf);
            }
        }
        private void InitSelectedIndex()
        {
            if ((imgList.Count > 0) &&
                (SelectedIndex == -1))
            {
                SelectedIndex = 0;
            }
            GetSelectedIndexFromController();

            IBranch parent = Controller.SelectedElement.Parent;
            if (parent == null)
            {
                ParentSelectedIndex = -1;
                ParentCount = -1;
                return;
            }

            ParentCount = parent.Count;
            ParentSelectedIndex = parent.IndexOf(Controller.SelectedElement) + 1;
        }
        private void ResetImageList()
        {
            imgList.Clear();
            SelectedIndex = -1;
        }
        private void SetControllerSelectedIndex(ILeaf leaf)
        {
            Controller.SelectedElement.SelectedIndex = Controller.SelectedElement.IndexOf(leaf);
        }

        private void FirstImage()
        {
            if (imgList.Count == 0) return;
            SelectedIndex = 0;
            LoadImage();
        }
        private void LastImage()
        {
            if (imgList.Count == 0) return;
            SelectedIndex = imgList.Count - 1;
            LoadImage();
        }
        private void NextImage()
        {
            if (imgList.Count == 0) return;
            SelectedIndex++;
            if (SelectedIndex >= imgList.Count)
            {
                if (switchFolderBtn.Checked)
                {
                    NextFolder();
                    return;
                }
                SelectedIndex = imgList.Count - 1;
            }
            LoadImage();
        }
        private void PreviousImage()
        {
            if (imgList.Count == 0) return;
            SelectedIndex--;
            if (SelectedIndex < 0)
            {
                if (switchFolderBtn.Checked)
                {
                    PreviousFolder();
                    return;
                }
                SelectedIndex = 0;
            }
            LoadImage();
        }
        private void RandomImage()
        {
            if (imgList.Count == 0) return;
            SelectedIndex = random.Next(imgList.Count);
            LoadImage();
        }

        private void JumpToParent(ParentSelection selection)
        {
            Controller.SelectParent(selection);
            BuildImageListFromSelectedElement();
            LoadImage();
        }
        private void NextFolder()
        {
            JumpToParent(ParentSelection.Next);
        }
        private void PreviousFolder()
        {
            JumpToParent(ParentSelection.Previous);
        }
        private void LoadImage()
        {
            ILeaf leaf = imgList[SelectedIndex];
            SetControllerSelectedIndex(leaf);
            picture.Image = GetImage(leaf);
            DeterminePictureMode(picture.Image.Height, picture.Image.Width);
            BuildCaptions(leaf);
        }
        private void UnloadImage()
        {
            ILeaf leaf = imgList[SelectedIndex];
            leaf.Unload();
        }

        private void BuildCaptions(ILeaf leaf)
        {
            string folderStr = "";
            if (leaf.Parent is IFolder)
            {
                IFolder folder = leaf.Parent as IFolder;
                Text = folder.Folder;
                folderStr = folder.Folder;
            }
            else
            {
                Text = leaf.Caption;
            }
            textLeft.Text = String.Format(leaf.Caption);
            textCenter.Text = String.Format("{0}   |   {1}",
                                            GetFileDataText(leaf), GetDimensionsText());
            textRight.Text = String.Format("{0}",
                                           GetSelectedIndexiesText());
            if (folderStr != "")
            {
                string[] list = folderStr.Split('\\');
                folderStr = list[list.Length - 1];    
            }
            HUDLabel.Text = textRight.Text + "\n" + textLeft.Text + "\n" + folderStr;
        }
        private void ToggleSlideshow(bool updateCaptionsOnly = false)
        {
            if (!updateCaptionsOnly)
            {
                slideShowTimer.Enabled = !slideShowTimer.Enabled;
                playBtn.Checked = slideShowTimer.Enabled;
            }
            if (playBtn.Checked)
            {
                playBtn.Text = "Current State = Playing";
            }
            else
            {
                playBtn.Text = "Current State = Stopped";
            }
        }
        private void ToggleShuffle(bool updateCaptionsOnly = false)
        {
            if (!updateCaptionsOnly)
            {
                shuffleBtn.Checked = !shuffleBtn.Checked;
            }
            if (shuffleBtn.Checked)
            {
                shuffleBtn.Text = "Current: Shuffle";
            }
            else
            {
                shuffleBtn.Text = "Current: Sequential";
            }
        }
        private void ToggleFolderSwitch(bool updateCaptionsOnly = false)
        {
            if (!updateCaptionsOnly)
            {
                switchFolderBtn.Checked = !switchFolderBtn.Checked;
            }
            if (switchFolderBtn.Checked)
            {
                switchFolderBtn.Text = "Current: Switch folder on last image";
            }
            else
            {
                switchFolderBtn.Text = "Current: Inactive";
            }
        }
        private void UpdateCaptions()
        {
            ToggleSlideshow(true);
            ToggleShuffle(true);
            ToggleFolderSwitch(true);
        }
        #endregion

        #region Public
        public ViewerDlg()
        {
            InitializeComponent();
        }
        public void Execute(ref ElementController controller)
        {
            Controller = controller;
            if (Controller == null) return;
            if (Controller.SelectedElement == null) return;
            if (Controller.SelectedElement.SelectedIndex == -1) return;

            BuildImageListFromSelectedElement();

            LoadImage();
            UpdateCaptions();
            ShowDialog();
        }
        #endregion

        #region WinForms Events
        private void ViewerDlg_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.R) JumpToParent(ParentSelection.Random);
                if (e.KeyCode == Keys.PageDown) NextFolder();
                if (e.KeyCode == Keys.PageUp) JumpToParent(ParentSelection.Previous);
                if (e.KeyCode == Keys.Home) JumpToParent(ParentSelection.First);
                if (e.KeyCode == Keys.End) JumpToParent(ParentSelection.Last);
                e.Handled = true;
                return;
            }
            if (e.Alt)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    fullScreen.Toogle();
                    SetWindowState();
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyCode == Keys.R)
            {
                RandomImage();
            }
            if (e.KeyCode == Keys.Home)
            {
                FirstImage();
            }
            if (e.KeyCode == Keys.End)
            {
                LastImage();
            }
            if (e.KeyCode == Keys.PageDown)
            {
                NextImage();
            }
            if (e.KeyCode == Keys.PageUp)
            {
                PreviousImage();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
            if (e.KeyCode == Keys.Space)
            {
                ToggleSlideshow();
            }
            if (e.KeyCode == Keys.S)
            {
                ToggleShuffle();
            }
            if (e.KeyCode == Keys.F)
            {
                ToggleFolderSwitch();
            }
        }

        private void SetWindowState()
        {
            if (fullScreen.IsFullScreen)
            {
                HUDLabel.Visible = true;
            }
            else
            {
                HUDLabel.Visible = false;
            }
        }
        private void ViewerDlg_OnResize(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void ViewerDlg_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            slideShowTimer.Enabled = false;
            playBtn.Checked = false;
        }

        private void SlideShowPlayPause_OnClick(object sender, EventArgs e)
        {
            ToggleSlideshow();
        }
        private void Shuffle_OnClick(object sender, EventArgs e)
        {
            ToggleShuffle();
        }
        private void SwitchFolderBtn_OnClick(object sender, EventArgs e)
        {
            ToggleFolderSwitch();
        }
        private void delayButtons_OnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem button = sender as ToolStripMenuItem;
            if (button != null)
            {
                int delay = 0;
                if (int.TryParse(button.ToolTipText, out delay))
                {
                    slideShowTimer.Interval = delay;
                }
                delayBtn.Text = "Slideshow Delay = " + Math.Round((double)slideShowTimer.Interval / (double)1000) + " Seconds";
            }
        }

        private void slideShowTimer_OnTick(object sender, EventArgs e)
        {
            if (playBtn.Checked)
            {
                playBtn.Text = "Current: Play";
            }
            else
            {
                playBtn.Text = "Current: Stopped";
            }

            if (shuffleBtn.Checked) 
            {
                RandomImage();
            }
             else 
            {
                NextImage();
            }
        }
        #endregion

        private void ViewerDlg_Load(object sender, EventArgs e)
        {
            fullScreen = FullScreen.Create(this);
            HUDLabel.Parent = picture;
            HUDLabel.BackColor = Color.Transparent;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
