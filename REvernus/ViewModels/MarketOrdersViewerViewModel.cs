using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        private DataTable OrderDataTable = new DataTable();
        private ConcurrentBag<DataRow> DataRows = new ConcurrentBag<DataRow>();

        public MarketOrdersViewerViewModel()
        {
            GetOrdersCommand = new DelegateCommand(async () => await GetMarketData());

            OrderDataTable.Columns.Add("Item Name", typeof(string));
            OrderDataTable.Columns.Add("Buy", typeof(double));
            OrderDataTable.Columns.Add("Sell", typeof(double));
            OrderDataTable.Columns.Add("Difference", typeof(double));
            OrderDataTable.Columns.Add("Buy Order Count", typeof(int));
            OrderDataTable.Columns.Add("Sell Order Count", typeof(int));
        }

        private async Task GetMarketData()
        {
            try
            {
                OrderDataTable.Clear();
                DataRows.Clear();

                // todo: implement type selection window

                var marketOrders = await EsiData.EsiClient.Market.ListOpenOrdersFromCharacterV2Async(
                    new AuthDTO()
                    {
                        AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                        CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                        Scopes = EVEStandard.Enumerations.Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1
                    });

                var types = await SdeData.GetInventoryTypesAsync();
                var displayTable = new DataTable();

                var taskList = new List<Task>();

                foreach (DataRow item in types.Rows)
                {
                    var typeId = (long) item["typeId"];
                    var typeName = (string) item["typeName"];
                    taskList.Add(MarketTask(typeId, typeName));
                }

                await Task.WhenAll(taskList);

                foreach (var dataRow in DataRows)
                {
                    OrderDataTable.Rows.Add(dataRow);
                }

                MarketOrders = OrderDataTable;

                // todo: get best sell and buy order for station
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task MarketTask(long typeId, string typeName)
        {
            try
            {
                var row = OrderDataTable.NewRow();

                row[0] = typeName;

                // todo: make station selector tool
                var orders = await Market.GetStationOrders(typeId, 60003760);
                Market.GetBestBuySell(orders, out var bestBuyOrder, out var bestSellOrder);

                row[1] = bestBuyOrder.Price;
                row[2] = bestSellOrder.Price;

                row[3] = bestSellOrder.Price - bestBuyOrder.Price;

                row[4] = orders.Count(o => o.IsBuyOrder);
                row[5] = orders.Count(o => !o.IsBuyOrder);

                DataRows.Add(row);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
