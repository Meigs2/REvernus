using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using REvernus.Models;

namespace REvernus.Views
{
    using Database.EveDbModels;

    /// <summary>
    /// Interaction logic for ItemExplorerView.xaml
    /// </summary>
    public partial class ItemExplorerView : Window
    {
        public List<InvTypes> SelectedTypes { get; set; } = new List<InvTypes>();

        public ItemExplorerView()
        {
            InitializeComponent();
        }

        private void ItemExplorerView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var a = new ItemTreeModel("All Items");
            TreeView1.ItemsSource = a.BuildTree();
        }

        private void ItemExplorerView_OnClosing(object sender, CancelEventArgs e)
        {
            SelectedTypes = (TreeView1.ItemsSource as List<ItemTreeModel>)?[0].GetSelected();
            (TreeView1.ItemsSource as List<ItemTreeModel>)?.Clear();
        }
    }
}
