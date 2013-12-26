using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AngelView.Core.Interfaces;
using AngelView.Core.Components;

namespace AngelView.Core.Models
{
    public class FileSearchBranch : BranchElement
    {
            public FileSearchBranch(List<FileInfo> files)
                : base(null)
            {
                _caption = "Search";
                foreach (var file in files)
                {
                    ILeaf leaf = LeafFactory.CreateFileLeaf(this, file);
                    _elementList.Add(leaf);
                }
                Sort(false);
            }

            public FileSearchBranch()
                : base(null)
            {
                _caption = "Search";
            }

            public override void Load()
            {
                // do nothing
            }

            public override void Sort(bool decending)
            {
                if (_elementList.Count > 2500)
                {
                    _elementList.Sort();
                }
                else
                {
                    base.Sort(decending);
                }
            }
    }
}
