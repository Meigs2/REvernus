using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using EVEStandard.API;
using EVEStandard.Models.API;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Utilities;
using Market = REvernus.Utilities.Market;

namespace REvernus.ViewModels
{
    public class MarketOrdersViewerViewModel : BindableBase
    {
        private DataTable _marketOrders;
        public DataTable MarketOrders
        {
            get => _marketOrders ??= new DataTable();
            set => SetProperty(ref _marketOrders, value);
        }

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MarketOrdersViewerViewModel()
        {
            GetOrdersCommand = new DelegateCommand(async () => await GetMarketData());
        }

        private async Task GetMarketData()
        {
            try
            {
                // todo: implement type selection window

                var marketOrders = await EsiData.EsiClient.Market.ListOpenOrdersFromCharacterV2Async(
                    new AuthDTO()
                    {
                        AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                        CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                        Scopes = EVEStandard.Enumerations.Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1
                    });

                MarketOrders = await MarketOrdersToOrderData(marketOrders.Model);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private async Task<DataTable> MarketOrdersToOrderData(List<EVEStandard.Models.CharacterMarketOrder> orderList)
        {
            var orderDataTable = new DataTable();
            var dataRows = new ConcurrentBag<DataRow>();
            var taskList = new List<Task>();

            orderDataTable.Columns.Add("Item Name", typeof(string));
            orderDataTable.Columns.Add("Buy", typeof(double));
            orderDataTable.Columns.Add("Sell", typeof(double));
            orderDataTable.Columns.Add("Difference", typeof(double));
            orderDataTable.Columns.Add("Buy Order Count", typeof(int));
            orderDataTable.Columns.Add("Sell Order Count", typeof(int));

            foreach (var order in orderList)
            {
                taskList.Add(Task.Run(async () => await MarketTask(order)));
            }

            await Task.WhenAll(taskList);

            foreach (var dataRow in dataRows)
            {
                orderDataTable.Rows.Add(dataRow);
            }

            return orderDataTable;

            async Task MarketTask(EVEStandard.Models.CharacterMarketOrder order)
            {
                try
                {
                    var row = orderDataTable.NewRow();

                    row[0] = SdeData.TypeIdToTypeName(order.TypeId);

                    // todo: make station selector tool
                    var orders = await Market.GetStationOrders(order.TypeId, 60003760);
                    Market.GetBestBuySell(orders, out var bestBuyOrder, out var bestSellOrder);

                    row[1] = bestBuyOrder.Price;
                    row[2] = bestSellOrder.Price;

                    row[3] = bestSellOrder.Price - bestBuyOrder.Price;

                    row[4] = orders.Count(o => o.IsBuyOrder);
                    row[5] = orders.Count(o => !o.IsBuyOrder);

                    dataRows.Add(row);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
