using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class ImageLeaf : FileLeaf, IImageLeaf
    {
        #region Fields
        protected Image _image = null;
        protected int _height = 0;
        protected int _width = 0;
        #endregion

        #region Constructors
        public ImageLeaf(IBranch Parent, string Filename)
            : base(Parent, Filename)
        {
        }
        public ImageLeaf(IBranch Parent, FileInfo fileinfo)
            : base(Parent, fileinfo)
        {
        }
        #endregion

        #region Properties
        public override Color BackgroundColor
        {
            get
            {
                if (Extension.ToUpper() == ".BMP") return Color.FromArgb(0xCCE9FF);
                if ((Extension.ToUpper() == ".JPG") ||
                    (Extension.ToUpper() == ".JPEG")) return Color.FromArgb(0xFFEEA5);
                if (Extension.ToUpper() == ".PNG") return Color.FromArgb(0xEECCFF);
                if (Extension.ToUpper() == ".GIF") return Color.FromArgb(0xBFFFC6);
                return Color.White;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
        }
        public Image Image
        {
            get
            {
                if (_image == null)
                {
                    Load();
                }
                return _image;
            }
        }
        public override string Type
        {
            get
            {
                return "Image (" + fileInfo.Extension + ")";
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }
        }
        #endregion

        #region Methods
        public override void Load()
        {
            if (_LoadState != LoadState.PendingLoad) return;
            _LoadState = LoadState.Loaded;
            _image = Image.FromFile(_filename);
            _height = _image.Height;
            _width = _image.Width;
        }
        public override void Unload()
        {
            _LoadState = LoadState.PendingLoad;
            _image = null;
        }
        #endregion
    }
}
