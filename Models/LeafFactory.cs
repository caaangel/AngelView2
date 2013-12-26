using AngelView.Core.Interfaces;
using AngelView.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Components
{
    public static class LeafFactory
    {
        public static IBranch CreateDriveBranch()
        {
            DriveBranch drives = new DriveBranch();
            return drives as IBranch;
        }
        public static IBranch CreateBranchFromFolder(string startUpFolder)
        {
            return CreateBranchFromFolder(null, startUpFolder);
        }
        public static IBranch CreateBranchFromFolder(IBranch Parent, string startUpFolder)
        {
            IBranch branch = null;
            if (startUpFolder == "")
            {
                branch = CreateDriveBranch();
            }
            else
            {
                branch = new FolderBranch(Parent, startUpFolder);
            }
            return branch;
        }

        public static ILeaf CreateFileLeaf(IBranch parent, string filename)
        {
            FileInfo fileinfo = new FileInfo(filename);
            return CreateFileLeaf(parent, fileinfo);
        }
        public static ILeaf CreateFileLeaf(IBranch parent, FileInfo fileInfo)
        {
            List<string> Imgs = ImageExtensions();
            if (Imgs.IndexOf(fileInfo.Extension.ToUpper()) > -1)
            {
                if (fileInfo.Extension.ToUpper() == ".IMGPACK")
                {
                    ImagePackageBranch branch = new ImagePackageBranch(parent, fileInfo);
                    return branch as LeafElement;
                }
                else
                {
                    ImageLeaf leaf = new ImageLeaf(parent, fileInfo);
                    return leaf;
                }
            }
            return new FileLeaf(parent, fileInfo);
        }

        public static bool ShouldIncludeFolder(DirectoryInfo dirInfo)
        {
            if ((dirInfo.Attributes & FileAttributes.System) != 0) return false;
            if ((dirInfo.Name == @"$RECYCLE.BIN") | (dirInfo.Name == "RECYCLER")) return false;
            return true;
        }
        public static bool ShouldIncludeFolder(string Folder)
        {
            DirectoryInfo itemInfo = new DirectoryInfo(Folder);
            return ShouldIncludeFolder(itemInfo);
        }

        public static bool ShouldIncludeFile(FileInfo fileInfo)
        {
            if ((fileInfo.Attributes & FileAttributes.System) != 0) return false;

            List<string> exts = LeafFactory.ImageExtensions();
            if (exts.IndexOf(fileInfo.Extension.ToUpper()) == -1) return false;
            return true;
        }
        public static bool ShouldIncludeFile(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            return ShouldIncludeFile(fileInfo);
        }

        public static List<string> ImageExtensions()
        {
            List<string> result = new List<string>();
            result.Add(".BMP");
            result.Add(".JPG");
            result.Add(".JPEG");
            result.Add(".PNG");
            result.Add(".GIF");
            result.Add(".IMGPACK");
            return result;
        }
    }
}
