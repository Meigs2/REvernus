using REvernus.Database.Contexts;
using REvernus.Database.EveDbModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace REvernus.Models
{
    public class ItemTreeModel : INotifyPropertyChanged
    {
        private readonly Dictionary<InvMarketGroups, ItemTreeModel> _dictionary =
            new Dictionary<InvMarketGroups, ItemTreeModel>();

        public ItemTreeModel(string name, bool isInitiallySelected)
        {
            Name = name;
            IsInitiallySelected = isInitiallySelected;
            Children = new List<ItemTreeModel>();
        }

        private void Initialize()
        {
            foreach (var child in Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        /// <summary>
        ///     Builds a tree for the TreeView. Call before building a tree for the ItemExplorer.
        /// </summary>
        /// <returns></returns>
        public List<ItemTreeModel> BuildTree()
        {
            IsExpanded = true;
            //Perform recursive method to build treeview 
            using var context = new EveContext();
            var items = context.InvTypes.Where(i => i.MarketGroup != null).ToList();
            var markets = context.InvMarketGroups.ToList();

            // Ensure marketGroupDictionary is created
            foreach (var market in markets)
            {
                _dictionary.Add(market, new ItemTreeModel(market.MarketGroupName, false));
                if (market.Parent == null) Children.Add(_dictionary[market]);
            }

            foreach (var market in markets)
                if (market.Parent != null)
                    _dictionary[market.Parent].Children.Add(_dictionary[market]);

            foreach (var item in items)
            {
                _dictionary[item.MarketGroup].HasItemChildren = true;
                _dictionary[item.MarketGroup].Children.Add(new ItemTreeModel(item.TypeName, false) { InvType = item });
            }

            Initialize();

            return new List<ItemTreeModel> { this };
        }

        /// <summary>
        ///     Returns a list of selected items from the Tree.
        /// </summary>
        /// <returns></returns>
        public List<InvTypes> GetSelected()
        {
            var toReturn = new List<InvTypes>();

            var parents = _dictionary.Values.Where(o => o.HasItemChildren).ToList();
            foreach (var parent in parents)
                foreach (var child in parent.Children)
                    if (child.InvType != null && child.IsChecked == true)
                        toReturn.Add(child.InvType);

            return toReturn;
        }

        #region Properties

        public string Name { get; }
        public InvTypes InvType { get; set; }
        public bool HasItemChildren { get; set; }
        public List<ItemTreeModel> Children { get; }
        public bool IsInitiallySelected { get; }
        public bool IsExpanded { get; set; }

        private bool? _isChecked = false;
        private ItemTreeModel _parent;

        #region IsChecked

        public bool? IsChecked
        {
            get => _isChecked;
            set => SetIsChecked(value, true, true);
        }

        private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked) return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue) Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent) _parent?.VerifyCheckedState();

            NotifyPropertyChanged("IsChecked");
        }

        private void VerifyCheckedState()
        {
            bool? state = null;

            for (var i = 0; i < Children.Count; ++i)
            {
                var current = Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }

            SetIsChecked(state, false, true);
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged Members

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}