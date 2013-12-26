using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public class DriveBranch : BranchElement
    {
        public DriveBranch()
            : base(null)
        {
            _caption = "Drives";
            Load();
        }

        public override void Load()
        {
            var drives = Environment.GetLogicalDrives();

            foreach (var drive in drives)
            {
                FolderBranch branch = new FolderBranch(this, drive);
                _elementList.Add(branch);
            }

            _LoadState = LoadState.Loaded;
        }
    }
}
