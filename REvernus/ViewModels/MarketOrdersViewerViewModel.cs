using EVEStandard.Models;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Utilities.StaticData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms.VisualStyles;
using EVEStandard.Models.API;
using ICSharpCode.SharpZipLib.Core;
using REvernus.Models;
using REvernus.Utilities;
using Market = REvernus.Utilities.Esi.Market;
using Status = REvernus.Utilities.Status;

namespace REvernus.ViewModels
{
    public class MarketOrdersViewerViewModel : BindableBase
    {
        public ObservableCollection<MarketOrderInfoModel> SellOrdersCollection { get; set; } = new ObservableCollection<MarketOrderInfoModel>();
        public ObservableCollection<MarketOrderInfoModel> BuyOrdersCollection { get; set; } = new ObservableCollection<MarketOrderInfoModel>();
            
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
                SellOrdersCollection.Clear();
                BuyOrdersCollection.Clear();

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
                        using var a = Status.GetNewStatusHandle();
                        ordersDict[location] = await Market.GetOrdersInStructure(auth, location, items.ToList());
                    }));
                }

                await Task.WhenAll(taskList);

                taskList.Clear();

                // Enable asynchronous access to a bindable collection for faster population of the datagrids.
                var buysLock = new object();
                var sellsLock = new object();
                BindingOperations.EnableCollectionSynchronization(BuyOrdersCollection, buysLock);
                BindingOperations.EnableCollectionSynchronization(SellOrdersCollection, sellsLock);

                foreach (var characterOrder in characterOrders)
                {
                    taskList.Add(Task.Run(async () =>
                    {
                        using var a = Status.GetNewStatusHandle();
                        // If something didn't go wrong along the way, we now have all the public orders in the location of our current order
                        if (ordersDict.TryGetValue(characterOrder.LocationId, out var idsToOrders) && idsToOrders.TryGetValue(characterOrder.TypeId, out var marketOrders))
                        {
                            var location = await StructureManager.GetStructureName(characterOrder.LocationId, auth);
                            var dataRow = new MarketOrderInfoModel(characterOrder, CharacterManager.SelectedCharacter, location, marketOrders);

                            if (dataRow.IsBuyOrder)
                            {
                                lock (buysLock)
                                {
                                    BuyOrdersCollection.Add(dataRow);
                                }
                            }
                            else
                            {
                                lock (sellsLock)
                                {
                                    SellOrdersCollection.Add(dataRow);
                                }
                            }
                        }
                    }));
                }

                await Task.WhenAll(taskList);
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

        public void RemoveItem(ObservableCollection<MarketOrderInfoModel> collection, MarketOrderInfoModel instance)
        {
            collection.Remove(collection.Single(i => i.Order.OrderId == instance.Order.OrderId));
        }
        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
