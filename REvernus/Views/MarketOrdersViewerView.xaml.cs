namespace REvernus.Views
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     Interaction logic for MarketOrdersViewerView.xaml
    /// </summary>
    public partial class MarketOrdersViewerView
    {
        public MarketOrdersViewerView()
        {
            InitializeComponent();
        }

        private void DataGridMouseDown(object sender, RoutedEventArgs routedEventArgs)
        {
            var clickedDataGrid = (DataGrid) sender;

            if (clickedDataGrid != SellDataGrid)
                SellDataGrid.UnselectAll();

            if (clickedDataGrid != BuyDataGrid)
                BuyDataGrid.UnselectAll();
        }
    }
}