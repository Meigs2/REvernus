using EVEStandard.Models;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Utilities.StaticData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
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
                var auth = new AuthDTO(){AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails, 
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId, 
                    Scopes = EVEStandard.Enumerations.Scopes.ESI_UNIVERSE_READ_STRUCTURES_1};

                var characterOrders = await CharacterManager.SelectedCharacter.GetCharacterMarketOrdersAsync();

                var locations = new HashSet<long>();
                var items = new HashSet<int>();

                foreach (var characterMarketOrder in characterOrders)
                {
                    locations.Add(characterMarketOrder.LocationId);
                    items.Add(characterMarketOrder.TypeId);
                }

                var taskList = new List<Task>();

                var sellOrdersDataTable = new DataTable { TableName = "Sell Orders" };
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


                // Dictionary contains the key of a location, and a dictionary of item ids to a list of orders
                var ordersDict = new Dictionary<long, Dictionary<int, List<MarketOrder>>>();

                foreach (var location in locations)
                {
                    ordersDict.Add(location, new Dictionary<int, List<MarketOrder>>());
                }

                foreach (var location in locations)
                {
                    taskList.Add(Task.Run(async () =>
                    {
                        ordersDict[location] = await Market.GetOrdersInStructure(auth, location, items.ToList());
                    }));
                }

                await Task.WhenAll(taskList);

                foreach (var characterOrder in characterOrders)
                {
                    // If something didnt go wrong along the way, we now have all the public orders in the location of our current order
                    if (ordersDict.TryGetValue(characterOrder.LocationId, out var idsToOrders) && idsToOrders.TryGetValue(characterOrder.TypeId, out var marketOrders))
                    {
                        var dataRow = characterOrder.IsBuyOrder == true ? buyOrdersDataTable.NewRow() : sellOrdersDataTable.NewRow();

                        dataRow["Item Name"] = EveItems.TypeIdToTypeName(characterOrder.TypeId);
                        dataRow["Item Id"] = characterOrder.TypeId;
                        dataRow["Location"] = await StructureManager.GetStructureName(characterOrder.LocationId, auth);
                        dataRow["Price"] = characterOrder.Price;
                        dataRow["Outbid"] = IsOutbid(marketOrders, characterOrder, out var difference);
                        dataRow["Difference"] = Math.Round(difference, 2, MidpointRounding.AwayFromZero);
                        dataRow["Volume"] = characterOrder.VolumeRemain + "/" + characterOrder.VolumeTotal;
                        dataRow["Total Value"] =
                            Math.Round(characterOrder.VolumeRemain * characterOrder.Price, MidpointRounding.AwayFromZero).ToString(CultureInfo.CurrentCulture);
                        dataRow["Owner"] =
                            CharacterManager.CharacterList.FirstOrDefault(c =>
                                c.CharacterDetails.CharacterId == auth.CharacterId)
                                ?.CharacterName;

                        if (characterOrder.VolumeTotal != characterOrder.VolumeRemain)
                        {
                            dataRow["Completion ETA"] = ((DateTime.Now - characterOrder.Issued) / (characterOrder.VolumeTotal - characterOrder.VolumeRemain)
                                                     * characterOrder.VolumeRemain).ToString(@"dd\:hh\:mm\:ss");
                        }
                        else
                        {
                            dataRow["Completion ETA"] = "Infinite";
                        }

                        if (characterOrder.IsBuyOrder == true)
                        {
                            buyOrdersDataTable.Rows.Add(dataRow.ItemArray);
                        }
                        else
                        {
                            sellOrdersDataTable.Rows.Add(dataRow.ItemArray);
                        }
                    }
                }

                SellOrdersDataTable = sellOrdersDataTable;
                BuyOrdersDataTable = buyOrdersDataTable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private bool IsOutbid(List<MarketOrder> marketOrders, CharacterMarketOrder order, out double difference)
        {
            difference = 0;

            if (order.IsBuyOrder == null || order.IsBuyOrder == false)
            {
                var buyOrders = marketOrders.Where(o => !o.IsBuyOrder).ToList();

                var min = buyOrders.OrderBy(o => o.Price).FirstOrDefault();
                if (min != null && order.OrderId != min.OrderId && min.Price <= order.Price)
                {
                    difference = min.Price - order.Price;
                    return true;
                }
            }
            else
            {
                var sellOrders = marketOrders.Where(o => o.IsBuyOrder).ToList();

                var max = sellOrders.OrderByDescending(o => o.Price).FirstOrDefault();
                if (max != null && order.OrderId != max.OrderId && max.Price >= order.Price)
                {
                    difference = max.Price - order.Price;
                    return true;
                }
            }

            return false;
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
