using AngelView.Core.Interfaces;
using GameTools.ImagePackage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class ImagePackageBranch : FileBranch
    {
        #region Constructors
        public ImagePackageBranch(IBranch Parent, string filename)
            : base(Parent, filename)
        {
        }
        public ImagePackageBranch(IBranch Parent, FileInfo fileinfo)
            : base(Parent, fileinfo)
        {
        }
        #endregion

        #region Properties
        public override Color BackgroundColor
        {
            get
            {
                return Color.FromArgb(0xFFBFBF);
            }
        }
        public override string Type
        {
            get
            {
                return "ImagePackage";
            }
        }
        #endregion

        #region Methods
        public override void Load()
        {
            if (_LoadState == LoadState.Loaded) return;
            _LoadState = LoadState.Loaded;

            ImagePackage imgPack = new ImagePackage();
            if (!imgPack.LoadFromFile(_filename)) return;

            VirtualImageLeaf leaf = null;
            int count = 0;
            foreach (Image img in imgPack)
            {
                leaf = new VirtualImageLeaf(this, img);
                leaf.Caption = "Stream #" + count.ToString();
                _elementList.Add(leaf);
                count++;
            }
        }
        public override void Unload()
        {
            foreach (VirtualImageLeaf imgLeaf in _elementList)
            {
                imgLeaf.Image = null;
            }
            _elementList.Clear();

            _LoadState = LoadState.PendingLoad;
        }
        #endregion
    }
}
