using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AngelView.Core.Interfaces
{
    public interface IFolder
    {
        DirectoryInfo GetParentDirectoryInfo
        {
            get;
        }
        string Folder
        {
            get;
        }

        void SortByDate(bool decending);
    }
}
