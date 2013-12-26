using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Interfaces
{
    public interface IFileData
    {
        Int64 Size
        {
            get;
        }

        DateTime Date
        {
            get;
        }

        string Extension
        {
            get;
        }
    }
}
