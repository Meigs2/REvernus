using EVEStandard.Models;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Utilities.StaticData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EVEStandard.Models.API;
using ICSharpCode.SharpZipLib.Core;
using REvernus.Models;
using Market = REvernus.Utilities.Esi.Market;

namespace REvernus.ViewModels
{
    public class MarketOrdersViewerViewModel : BindableBase
    {
        private DataTable _sellOrdersDataTable;
        public DataTable SellOrdersDataTable
        {
            get => _sellOrdersDataTable ??= new DataTable();
            set => SetProperty(ref _sellOrdersDataTable, value);
        }

        private DataTable _buyOrdersDataTable;
        public DataTable BuyOrdersDataTable
        {
            get => _buyOrdersDataTable ??= new DataTable();
            set => SetProperty(ref _buyOrdersDataTable, value);
        }

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MarketOrdersViewerViewModel()
        {
            GetOrdersCommand = new DelegateCommand(async () => await GetOrderInformation());
        }

        private async Task GetOrderInformation()
        {
            try
            {
                var marketOrders = await CharacterManager.SelectedCharacter.GetCharacterMarketOrdersAsync();
                var selectedCharacter = CharacterManager.SelectedCharacter;

                var (sellOrderDataTable, buyOrderDataTable) = await MarketOrdersToOrderData(marketOrders, selectedCharacter);
                SellOrdersDataTable = sellOrderDataTable;
                BuyOrdersDataTable = buyOrderDataTable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private async Task<(DataTable sellOrderDataTable, DataTable buyOrderDataTable)> MarketOrdersToOrderData(List<CharacterMarketOrder> orderList, REvernusCharacter selectedCharacter)
        {
            var locations = new List<long>();
            var items = new List<int>();

            foreach (var characterMarketOrder in orderList)
            {
                locations.Add(characterMarketOrder.LocationId);
                items.Add(characterMarketOrder.TypeId);
            }

            Market.GetOrdersFromOrders(locations);

            var sellOrderRows = new ConcurrentBag<DataRow>();
            var buyOrderRows = new ConcurrentBag<DataRow>();
            var taskList = new List<Task>();

            var sellOrdersDataTable = new DataTable {TableName = "Sell Orders" };
            sellOrdersDataTable.Columns.Add("Item Name", typeof(string));
            sellOrdersDataTable.Columns.Add("Item Id", typeof(int));
            sellOrdersDataTable.Columns.Add("Location", typeof(string));
            sellOrdersDataTable.Columns.Add("Price", typeof(double));
            sellOrdersDataTable.Columns.Add("Outbid", typeof(bool));
            sellOrdersDataTable.Columns.Add("Difference", typeof(double));
            sellOrdersDataTable.Columns.Add("Volume", typeof(string));
            sellOrdersDataTable.Columns.Add("Total Value", typeof(double));
            sellOrdersDataTable.Columns.Add("Completion ETA", typeof(string));
            sellOrdersDataTable.Columns.Add("Owner", typeof(string));

            var buyOrdersDataTable = sellOrdersDataTable.Clone();
            buyOrdersDataTable.TableName = "Buy Orders";

            foreach (var order in orderList)
            {
                if ((order.IsBuyOrder == true))
                {
                    var row = buyOrdersDataTable.NewRow();
                    taskList.Add(Task.Run(async () => await MarketTask(
                        new AuthDTO() {AccessToken = selectedCharacter.AccessTokenDetails, 
                        CharacterId = selectedCharacter.CharacterDetails.CharacterId, 
                        Scopes = EVEStandard.Enumerations.Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1}, order, row, buyOrderRows)));
                }
                else
                {
                    var row = sellOrdersDataTable.NewRow();
                    taskList.Add(Task.Run(async () => await MarketTask(
                        new AuthDTO()
                        {
                            AccessToken = selectedCharacter.AccessTokenDetails,
                            CharacterId = selectedCharacter.CharacterDetails.CharacterId,
                            Scopes = EVEStandard.Enumerations.Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1
                        }, order, row, sellOrderRows)));
                }
            }

            await Task.WhenAll(taskList);

            foreach (var sellOrderRow in sellOrderRows)
            {
                sellOrdersDataTable.Rows.Add(sellOrderRow.ItemArray);
            }

            foreach (var buyOrderRow in buyOrderRows)
            {
                buyOrdersDataTable.Rows.Add(buyOrderRow.ItemArray);
            }

            return (sellOrdersDataTable, buyOrdersDataTable);
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
