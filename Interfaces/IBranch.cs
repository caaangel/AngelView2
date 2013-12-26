using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngelView.Core.Interfaces;

namespace AngelView.Core.Interfaces
{
    public interface IBranch : ILeaf
    {
        int Count
        {
            get;
        }

        int SelectedIndex
        {
            get;
            set;
        }

        // Indexer - Delphi equalent is Property Items[Index: Integer]: XXX read GETItems write SETItems; Default;
        ILeaf this[int index]
        {
            get; set;
        }

        ILeaf GetFirst();
        int GetFirstIndex();
        ILeaf GetLast();
        int GetLastIndex();
        List<T> GetList<T>();
        void Sort(bool ascending);

        void Add(ILeaf leaf);
        void Delete(int index);
        void Clear();
        int IndexOf(ILeaf leaf);
    }
}
