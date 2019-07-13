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
using System.Threading.Tasks;
using Market = REvernus.Utilities.Esi.Market;

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
                var marketOrders = await CharacterManager.SelectedCharacter.GetCharacterMarketOrdersAsync();

                MarketOrders = await MarketOrdersToOrderData(marketOrders);
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
            orderDataTable.Columns.Add("Location", typeof(string));
            orderDataTable.Columns.Add("Price", typeof(double));
            orderDataTable.Columns.Add("Outbid", typeof(bool));
            orderDataTable.Columns.Add("Volume", typeof(string));
            orderDataTable.Columns.Add("Total Value", typeof(double));
            orderDataTable.Columns.Add("Completion ETA", typeof(string));

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
                    using var handle = Utilities.Status.GetNewStatusHandle();
                    var stationOrders = await Market.GetStationOrders(characterItemOrder.TypeId, 60003760);
                    Market.GetBestBuySell(stationOrders, out var bestBuyOrder, out var bestSellOrder);

                    row["Item Name"] = EveItems.TypeIdToTypeName(characterItemOrder.TypeId);

                    row["Location"] = Structures.GetStructureName(characterItemOrder.LocationId);

                    row["Price"] = characterItemOrder.Price;

                    row["Outbid"] = IsOutbid(characterItemOrder, bestBuyOrder, bestSellOrder);

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

                    dataRows.Add(row);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private bool IsOutbid(CharacterMarketOrder characterItemOrder, MarketOrder bestBuyOrder, MarketOrder bestSellOrder)
        {
            if (characterItemOrder.IsBuyOrder is true)
                return characterItemOrder.Price < bestBuyOrder.Price;

            if (characterItemOrder.IsBuyOrder == null || characterItemOrder.IsBuyOrder is false)
                return characterItemOrder.Price > bestSellOrder.Price;

            return false;
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
