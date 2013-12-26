using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AngelView.Core.Models;

namespace AngelView.Core.Interfaces
{
    public interface ILeaf
    {
        NodeType NodeType
        {
            get;
        }

        Color BackgroundColor
        {
            get;
        }
        string Caption
        {
            get;
            set;
        }
        Color FontColor
        {
            get;
        }
        LoadState IsLoaded
        {
            get;
        }
        IBranch Parent
        {
            get;
        }
        string Type
        {
            get;
        }

        void Load();
        void Unload();
    }
}
