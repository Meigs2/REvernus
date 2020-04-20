using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EVEStandard.Models;
using REvernus.Models;
using REvernus.Models.EveDbModels;

namespace REvernus.Views
{
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
