using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gma.System.MouseKeyHook;
using REvernus.Core;

namespace REvernus.Views
{
    /// <summary>
    /// Interaction logic for MarketOrdersViewerView.xaml
    /// </summary>
    public partial class MarketOrdersViewerView : UserControl
    {
        public MarketOrdersViewerView()
        {
            InitializeComponent();
        }

        private void DataGridMouseDown(object sender, RoutedEventArgs routedEventArgs)
        {
            var clickedDataGrid = (DataGrid) sender;

            if (clickedDataGrid != BuyAndSellOrdersSellDataGrid)
            {
                BuyAndSellOrdersSellDataGrid.UnselectAll();
            }

            if (clickedDataGrid != BuyAndSellOrdersBuyDataGrid)
            {
                BuyAndSellOrdersBuyDataGrid.UnselectAll();
            }
        }
    }
}
