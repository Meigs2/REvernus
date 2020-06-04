using System.Windows;
using System.Windows.Controls;

namespace REvernus.Views
{
    /// <summary>
    ///     Interaction logic for MarketOrdersViewerView.xaml
    /// </summary>
    public partial class MarketOrdersViewerView : UserControl
    {
        public MarketOrdersViewerView()
        {
            InitializeComponent();
        }

        private void DataGridMouseDown(object sender, RoutedEventArgs routedEventArgs)
        {
            var clickedDataGrid = (DataGrid)sender;

            if (clickedDataGrid != SellDataGrid) SellDataGrid.UnselectAll();

            if (clickedDataGrid != BuyDataGrid) BuyDataGrid.UnselectAll();
        }
    }
}