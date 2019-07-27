using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        private IKeyboardMouseEvents _keybindEvents = Hook.GlobalEvents();

        public MarketOrdersViewerView()
        {
            SubscribeHotkeys();
            AppDomain.CurrentDomain.ProcessExit += UnsubscribeHotkeys;
            InitializeComponent();
        }

        private void UnsubscribeHotkeys(object sender, EventArgs e)
        {
            _keybindEvents.Dispose();
        }

        private void UnsubscribeHotkeys()
        {
            _keybindEvents.Dispose();
        }

        private void SubscribeHotkeys()
        {
            UnsubscribeHotkeys();

            _keybindEvents = Hook.GlobalEvents();

            var actions = new Dictionary<Combination, Action>()
            {
                {Combination.FromString("Shift+Up"), async () => await KeyBindMoveUp()},
                { Combination.FromString("Shift+Down"), async () => await KeyBindMoveDown()}
            };

            _keybindEvents.OnCombination(actions);
        }

        private async Task KeyBindMoveUp()
        {
            await MoveSelectedRow(Key.Up);
        }

        private async Task KeyBindMoveDown()
        {
            await MoveSelectedRow(Key.Down);
        }

        private async Task MoveSelectedRow(Key direction)
        {
            var selectedDataGrid = GetSelectedDataGrid();

            if (selectedDataGrid == null)
            {
                return;
            }

            // Get next index
            var currentRow = selectedDataGrid.SelectedIndex;

            var nextRow = direction == Key.Up ? currentRow - 1 : currentRow + 1;

            if (nextRow < 0)
            {
                return;
            }

            if (nextRow >= selectedDataGrid.Items.Count)
            {
                return;
            }

            selectedDataGrid.SelectedIndex = nextRow;
            selectedDataGrid.SelectedItem = selectedDataGrid.Items[selectedDataGrid.SelectedIndex];

            var row = (DataRowView) selectedDataGrid.SelectedItem;
            var orderOwner = CharacterManager.CharacterList.FirstOrDefault(
                s => s.CharacterName != null && 
                     s.CharacterName == (string)row.Row.ItemArray[row.Row.Table.Columns["Owner"].Ordinal]);
            var itemId = (int)row.Row.ItemArray[row.Row.Table.Columns["Item Id"].Ordinal];

            if (orderOwner != null) await orderOwner.OpenMarketWindow(itemId);
        }

        private DataGrid GetSelectedDataGrid()
        {
            if (BuyAndSellOrdersSellDataGrid.SelectedCells.Count > 0)
            {
                return BuyAndSellOrdersSellDataGrid;
            }

            if (BuyAndSellOrdersBuyDataGrid.SelectedCells.Count > 0)
            {
                return BuyAndSellOrdersBuyDataGrid;
            }

            if (SellOnlyDataGrid.SelectedCells.Count > 0)
            {
                return SellOnlyDataGrid;
            }

            if (BuyOnlyDataGrid.SelectedCells.Count > 0)
            {
                return BuyOnlyDataGrid;
            }

            return null;
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

            if (clickedDataGrid != SellOnlyDataGrid)
            {
                SellOnlyDataGrid.UnselectAll();
            }

            if (clickedDataGrid != BuyOnlyDataGrid)
            {
                BuyOnlyDataGrid.UnselectAll();
            }
        }
    }
}
