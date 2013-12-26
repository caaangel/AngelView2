using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Interfaces
{
    public interface IImageLeaf : IFileData, ILeaf
    {
        Image Image
        {
            get;
        }

        int Height
        {
            get;
        }

        int Width
        {
            get;
        }
    }
}
