using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public abstract class BranchElement : LeafElement, IBranch
    {
        #region Fields
        protected List<ILeaf> _elementList;
        #endregion

        #region Constructors
        public BranchElement(IBranch Parent)
            : base(Parent)
        {
            _nodeType = NodeType.Branch;
            _elementList = new List<ILeaf>();
            SelectedIndex = -1;
        }
        #endregion

        #region Properties
        public ILeaf this[int index]
        {
            // Indexer - Delphi equalent of Property Items[Index: Integer]: XXX read GETItems write SETItems; Default;
            get
            {
                return _elementList[index];
            }
            set
            {
                _elementList[index] = value;
            }
        }
        public int Count
        {
            get { return _elementList.Count; }
        }
        public int SelectedIndex
        {
            get;
            set;
        }
        #endregion

        #region Methods
        public void Clear()
        {
            _elementList.Clear();
        }
        public void Delete(int index)
        {
            _elementList.RemoveAt(index);
        }
        public ILeaf GetFirst()
        {
            if (_elementList.Count == 0) return null;
            return _elementList[0];
        }
        public int GetFirstIndex()
        {
            return (_elementList.Count == 0) ? -1 : 0;
        }
        public ILeaf GetLast()
        {
            if (_elementList.Count == 0) return null;
            return _elementList[_elementList.Count - 1];
        }
        public int GetLastIndex()
        {
            if (_elementList.Count == 0) return -1;
            return _elementList.Count - 1;
        }
        public int IndexOf(ILeaf leaf)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == leaf)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Add(ILeaf leaf)
        {
            _elementList.Add(leaf);
        }

        public List<T> GetList<T>()
        {
            var list = new List<T>();
            foreach (var e in _elementList)
            {
                if (e is T)
                {
                    list.Add((T)e);
                }
            }

            return list;
        }

        public override void Unload()
        {
            foreach (ILeaf leaf in _elementList)
            {
                leaf.Unload();
            }
        }

        public virtual long Compare(ILeaf leaf1, ILeaf leaf2)
        {
            long long1;
            long long2;
            if ((Int64.TryParse(leaf1.Caption.Split('.')[0], out long1)) &&
                (Int64.TryParse(leaf2.Caption.Split('.')[0], out long2)))
            {
                return long1 - long2;
            }
            else
            {
                return String.Compare(leaf1.Caption, leaf2.Caption);
            }
        }
        public virtual void Sort(bool decending)
        {
            if (_elementList.Count == 0) return;

            int at = 0;
            bool directionSet;
            long res;
            ILeaf swapper;

            while ((at > -1) && (at < _elementList.Count))
            {
                directionSet = false;
                if (at < _elementList.Count - 1)
                {
                    res = Compare(_elementList[at], _elementList[at + 1]);
                    if (!decending) res = res * -1;
                    if (res < 0)
                    {
                        swapper = _elementList[at];
                        _elementList[at] = _elementList[at + 1];
                        _elementList[at + 1] = swapper;
                    }
                }

                if (at >= 1)
                {
                    res = Compare(_elementList[at], _elementList[at - 1]);
                    if (!decending) res = res * -1;
                    if (res > 0)
                    {
                        swapper = _elementList[at];
                        _elementList[at] = _elementList[at - 1];
                        _elementList[at - 1] = swapper;
                        at--;
                        directionSet = true;
                    }
                }

                if (!directionSet)
                {
                    at++;
                }
            }
        }
        #endregion
    }
}
