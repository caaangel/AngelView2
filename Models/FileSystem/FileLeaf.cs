using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class FileLeaf : LeafElement, IFileData
    {
        #region Fields
        protected FileInfo fileInfo;
        protected string _filename;
        #endregion

        #region Constructors
        public FileLeaf(IBranch Parent, string Filename)
            : base(Parent)
        {
            _filename = Filename;
            fileInfo = new FileInfo(Filename);
        }
        public FileLeaf(IBranch Parent, FileInfo FileInfo)
            : base(Parent)
        {
            _filename = FileInfo.FullName;
            fileInfo = FileInfo;
        }
        #endregion

        #region Properties
        public Int64 Size
        {
            get { return fileInfo.Length; }
        }
        public string Extension
        {
            get { return fileInfo.Extension; }
        }
        public DateTime Date
        {
            get { return fileInfo.LastWriteTime; }
        }
        public override string Type
        {
            get
            {
                return fileInfo.Extension;
            }
        }
        public override string Caption
        {
            get
            {
                return fileInfo.Name;
            }
        }
        #endregion

        #region Methods
        public override void Load()
        {
            // do nothing
        }
        public override void Unload()
        {
            // do nothing
        }
        #endregion
    }
}
