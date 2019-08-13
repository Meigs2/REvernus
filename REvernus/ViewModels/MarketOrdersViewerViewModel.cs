using EVEStandard.Models;
using EVEStandard.Models.API;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Utilities.StaticData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
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
                var selectedCharacter = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId;

                var (sellOrderDataTable, buyOrderDataTable) = await MarketOrdersToOrderData(marketOrders, selectedCharacter);
                SellOrdersDataTable = sellOrderDataTable;
                BuyOrdersDataTable = buyOrderDataTable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private readonly string _tableName = "Orders";
        private async Task<(DataTable sellOrderDataTable, DataTable buyOrderDataTable)> MarketOrdersToOrderData(List<CharacterMarketOrder> orderList, int selectedCharacterId)
        {
            var sellOrderRows = new ConcurrentBag<DataRow>();
            var buyOrderRows = new ConcurrentBag<DataRow>();
            var taskList = new List<Task>();

            var sellOrdersDataTable = new DataTable {TableName = _tableName};
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

            foreach (var order in orderList)
            {
                var row = sellOrdersDataTable.NewRow();
                taskList.Add(Task.Run(async () => await MarketTask(order, row)));
            }

            await Task.WhenAll(taskList);

            foreach (var sellOrderRow in sellOrderRows)
            {
                sellOrdersDataTable.Rows.Add(sellOrderRow);
            }

            foreach (var buyOrderRow in buyOrderRows)
            {
                buyOrdersDataTable.Rows.Add(buyOrderRow);
            }

            return (sellOrdersDataTable, buyOrdersDataTable);

            async Task MarketTask(CharacterMarketOrder characterItemOrder, DataRow row)
            {
                try
                {
                    using var handle = Utilities.Status.GetNewStatusHandle();
                    var stationOrders = await Market.GetStationOrders(characterItemOrder.TypeId, 60003760);
                    Market.GetBestBuySell(stationOrders, out var bestBuyOrder, out var bestSellOrder);

                    row["Item Name"] = EveItems.TypeIdToTypeName(characterItemOrder.TypeId);
                    row["Item Id"] = characterItemOrder.TypeId;
                    row["Location"] = Structures.GetStructureName(characterItemOrder.LocationId);
                    row["Price"] = characterItemOrder.Price;
                    row["Outbid"] = IsOutbid(characterItemOrder, bestBuyOrder, bestSellOrder, out var difference);
                    row["Difference"] = Math.Round(difference, 2, MidpointRounding.ToEven);
                    row["Volume"] = $"{characterItemOrder.VolumeRemain}/{characterItemOrder.VolumeTotal}";
                    row["Total Value"] = Math.Round(characterItemOrder.Price * characterItemOrder.VolumeRemain, 2, MidpointRounding.ToEven);

                    if (characterItemOrder.VolumeTotal != characterItemOrder.VolumeRemain)
                    {
                        row["Completion ETA"] = ((DateTime.Now - characterItemOrder.Issued) / (characterItemOrder.VolumeTotal - characterItemOrder.VolumeRemain)
                                                 * characterItemOrder.VolumeRemain).ToString(@"dd\:hh\:mm\:ss");
                    }
                    else
                    {
                        row["Completion ETA"] = "Infinite";
                    }

                    if ((characterItemOrder.IsBuyOrder == true))
                    {
                        buyOrderRows.Add(row);
                    }
                    else
                    {
                        sellOrderRows.Add(row);
                    }

                    row["Owner"] = CharacterManager.CharacterList
                        .FirstOrDefault(s => s.CharacterDetails.CharacterId == selectedCharacterId)
                        ?.CharacterName;
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private bool IsOutbid(CharacterMarketOrder characterItemOrder, MarketOrder bestBuyOrder, MarketOrder bestSellOrder, out double outbidDifference)
        {
            outbidDifference = 0.0;

            if (characterItemOrder.IsBuyOrder is true)
            {
                if (characterItemOrder.Price < bestBuyOrder.Price)
                {
                    outbidDifference = bestBuyOrder.Price - characterItemOrder.Price;
                    return true;
                }
            }

            if (characterItemOrder.IsBuyOrder == null || characterItemOrder.IsBuyOrder is false)
            {
                if (characterItemOrder.Price > bestSellOrder.Price)
                {
                    outbidDifference = bestSellOrder.Price - characterItemOrder.Price;
                    return true;
                }
            }

            return false;
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
