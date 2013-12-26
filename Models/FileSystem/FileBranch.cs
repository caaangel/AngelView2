using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class FileBranch : BranchElement, IFileData
    {
        #region Fields
        protected FileInfo _fileInfo;
        protected string _filename;
        #endregion

        #region Constructors
        public FileBranch(IBranch Parent, string Filename)
            : base(Parent)
        {
            _filename = Filename;
            _fileInfo = new FileInfo(Filename);
        }
        public FileBranch(IBranch Parent, FileInfo fileinfo)
            : base(Parent)
        {
            _filename = fileinfo.FullName;
            _fileInfo = fileinfo;
        }
        #endregion

        #region Properties
        public override string Caption
        {
            get
            {
                return _fileInfo.Name;
            }
        }
        public DateTime Date
        {
            get { return _fileInfo.LastWriteTime; }
        }
        public string Extension
        {
            get { return _fileInfo.Extension; }
        }
        public Int64 Size
        {
            get { return _fileInfo.Length; }
        }
        public override string Type
        {
            get
            {
                return _fileInfo.Extension;
            }
        }
        #endregion

        #region Methods
        public override void Load()
        {
        }
        #endregion
    }
}
