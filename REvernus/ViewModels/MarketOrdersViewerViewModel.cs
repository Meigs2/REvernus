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
using System.Windows.Forms;
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

        private readonly string _tableName = "Orders";
        private async Task<DataTable> MarketOrdersToOrderData(List<EVEStandard.Models.CharacterMarketOrder> orderList)
        {
            var orderDataTable = new DataTable();
            var dataRows = new ConcurrentBag<DataRow>();
            var taskList = new List<Task>();

            orderDataTable.TableName = _tableName;

            orderDataTable.Columns.Add("Item Name", typeof(string));
            orderDataTable.Columns.Add("Buy", typeof(double));
            orderDataTable.Columns.Add("Sell", typeof(double));
            orderDataTable.Columns.Add("Difference", typeof(double));
            orderDataTable.Columns.Add("Percent Difference", typeof(double));
            orderDataTable.Columns.Add("Buy Order Count", typeof(int));
            orderDataTable.Columns.Add("Sell Order Count", typeof(int));


            foreach (var order in orderList)
            {
                var row = orderDataTable.NewRow();
                taskList.Add(Task.Run(async () => await MarketTask(order, row)));
            }

            await Task.WhenAll(taskList);

            foreach (var dataRow in dataRows)
            {
                orderDataTable.Rows.Add(dataRow);
            }

            return orderDataTable;

            async Task MarketTask(EVEStandard.Models.CharacterMarketOrder characterItemOrder, DataRow row)
            {
                try
                {
                    row["Item Name"] = SdeData.TypeIdToTypeName(characterItemOrder.TypeId);

                    // todo: make station selector tool
                    var stationOrders = await Market.GetStationOrders(characterItemOrder.TypeId, 60003760);
                    Market.GetBestBuySell(stationOrders, out var bestBuyOrder, out var bestSellOrder);

                    row["Buy"] = Math.Round(bestBuyOrder.Price, 2, MidpointRounding.ToEven);
                    row["Sell"] = Math.Round(bestSellOrder.Price, 2, MidpointRounding.ToEven);

                    row["Difference"] = Math.Round((bestSellOrder.Price - bestBuyOrder.Price), 2, MidpointRounding.ToEven);
                    row["Percent Difference"] =
                        Math.Round((bestSellOrder.Price - bestBuyOrder.Price) / bestBuyOrder.Price,
                            2, MidpointRounding.ToEven);

                    row["Buy Order Count"] = stationOrders.Count(o => o.IsBuyOrder);
                    row["Sell Order Count"] = stationOrders.Count(o => !o.IsBuyOrder);

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
