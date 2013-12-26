using AngelView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelView.Core.Models
{
    public enum NodeType
    {
        Branch,
        Leaf
    }
    public enum LoadState
    {
        PendingLoad,
        Loaded
    }

    public abstract class LeafElement : ILeaf
    {
        #region Fields
        protected NodeType _nodeType;
        protected string _caption;
        protected LoadState _LoadState;
        protected IBranch _parent;
        protected string _type;
        #endregion

        #region Constructors
        public LeafElement(IBranch Parent)
        {
            _parent = Parent;
            _nodeType = NodeType.Leaf;
            _LoadState = LoadState.PendingLoad;
        }
        #endregion

        #region Properties
        public virtual Color BackgroundColor
        {
            get { return Color.White; }
        }
        public virtual string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        public virtual Color FontColor
        {
            get { return Color.Black; }
        }
        public LoadState IsLoaded
        {
            get { return _LoadState; }
        }
        public NodeType NodeType
        {
            get { return _nodeType; }
        }
        public IBranch Parent
        {
            get { return _parent; }
            set { }
        }
        public virtual string Type
        {
            get { return _type; }
        }
        #endregion

        #region Methods
        public abstract void Load();
        public abstract void Unload();
        #endregion
    }
}
