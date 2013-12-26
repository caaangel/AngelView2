using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class VirtualImageLeaf : LeafElement, IImageLeaf
    {
        #region Fields
        protected Image _image = null;
        #endregion

        #region Constructors
        public VirtualImageLeaf(IBranch Parent, Image img)
            : base(Parent)
        {
            _image = img;
            _LoadState = LoadState.Loaded;
        }
        #endregion

        #region Properties
        public DateTime Date
        {
            get
            {
                IFileData parent = _parent as IFileData;
                return parent.Date;
            }
        }
        public string Extension
        {
            get
            {
                IFileData parent = _parent as IFileData;
                return parent.Extension;
            }
        }
        public int Height
        {
            get
            {
                return _image.Height;
            }
        }
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public Int64 Size
        {
            get { return 0; }
        }
        public override string Type
        {
            get
            {
                return "Image Stream";
            }
        }
        public int Width
        {
            get
            {
                return _image.Width;
            }
        }
        #endregion

        #region Methods
        public override void Load()
        {
            // Do nothing
        }
        public override void Unload()
        {
            // Do nothing
            // ImageStreamLeaf cannot be reconstructed from filedate, so it must be unloaded from the parent
        }
        #endregion
    }
}
