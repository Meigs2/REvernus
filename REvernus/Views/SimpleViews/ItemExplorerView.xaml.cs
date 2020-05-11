using REvernus.Database.EveDbModels;
using REvernus.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace REvernus.Views.SimpleViews
{
    /// <summary>
    ///     Interaction logic for ItemExplorerView.xaml
    /// </summary>
    public partial class ItemExplorerView : Window
    {
        public bool WasCanceled = true;

        /// <summary>
        ///     Creates a new instance of an ItemExplorer window.
        ///     Always check <code>WasCanceled</code> to check if the user actually selected items.
        /// </summary>
        public ItemExplorerView()
        {
            InitializeComponent();
        }

        public List<InvTypes> SelectedTypes { get; set; } = new List<InvTypes>();

        private void ItemExplorerView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var itemTreeModel = new ItemTreeModel("All Items", false);
            TreeView1.ItemsSource = itemTreeModel.BuildTree();
        }

        private void ItemExplorerView_OnClosing(object sender, CancelEventArgs e)
        {
            if (!WasCanceled) SelectedTypes = (TreeView1.ItemsSource as List<ItemTreeModel>)?[0].GetSelected();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            WasCanceled = false;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}