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
using System.Windows.Input;
using EVEStandard.Models.API;
using Gma.System.MouseKeyHook;
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

        public object SellsSelectedItem
        {
            get => _sellsSelectedItem;
            set => SetProperty(ref _sellsSelectedItem, value);
        }
        public int SellsSelectedIndex
        {
            get => _sellsSelectedIndex;
            set => SetProperty(ref _sellsSelectedIndex, value);
        }
        public object BuysSelectedItem
        {
            get => _buysSelectedItem;
            set => SetProperty(ref _buysSelectedItem, value);
        }
        public int BuysSelectedIndex
        {
            get => _buysSelectedIndex;
            set => SetProperty(ref _buysSelectedIndex, value);
        }
        public DelegateCommand GetOrdersEsiCommand { get; set; }

        private IKeyboardMouseEvents _keybindEvents = Hook.GlobalEvents();
        private int _sellsSelectedIndex;
        private object _sellsSelectedItem;
        private int _buysSelectedIndex;
        private object _buysSelectedItem;

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MarketOrdersViewerViewModel()
        {
            GetOrdersEsiCommand = new DelegateCommand(async () => await LoadOrdersFromEsi());
            SubscribeHotKeys();
            AppDomain.CurrentDomain.ProcessExit += UnsubscribeHotKeys;
        }

        private void UnsubscribeHotKeys(object sender, EventArgs e)
        {
            _keybindEvents.Dispose();
        }

        private void UnsubscribeHotKeys()
        {
            _keybindEvents.Dispose();
        }

        private void SubscribeHotKeys()
        {
            UnsubscribeHotKeys();

            _keybindEvents = Hook.GlobalEvents();

            var actions = new Dictionary<Combination, Action>()
            {
                {Combination.FromString("Alt+Up"),  KeyBindMoveUp},
                {Combination.FromString("Alt+Down"), KeyBindMoveDown}
            };

            _keybindEvents.OnCombination(actions);
        }

        private void KeyBindMoveUp()
        {
        }

        private void KeyBindMoveDown()
        {
        }

        private async Task LoadOrdersFromEsi()
        {
            var characterOrders = await CharacterManager.SelectedCharacter.GetCharacterMarketOrdersAsync();
            await ImportOrders(characterOrders);
        }

        private async Task ImportOrders(List<CharacterMarketOrder> characterOrders)
        {
            try
            {
                var auth = new AuthDTO(){AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails, 
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId, 
                    Scopes = EVEStandard.Enumerations.Scopes.ESI_UNIVERSE_READ_STRUCTURES_1};

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
                            var location = await StructureManager.GetStructureName(characterOrder.LocationId);

                            var existingOrder = BuyOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId);
                            if (existingOrder != null && characterOrder.IsBuyOrder == true)
                            {
                                existingOrder.Order = characterOrder;
                                existingOrder.Owner = CharacterManager.SelectedCharacter.CharacterName;
                                existingOrder.MarketOrders = marketOrders;
                                existingOrder.LocationName = location;
                                return;
                            }

                            existingOrder = SellOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId);
                            if (existingOrder != null && characterOrder.IsBuyOrder != true)
                            {
                                existingOrder.Order = characterOrder;
                                existingOrder.Owner = CharacterManager.SelectedCharacter.CharacterName;
                                existingOrder.MarketOrders = marketOrders;
                                existingOrder.LocationName = location;
                                return;
                            }

                            var newRow = new MarketOrderInfoModel(characterOrder, CharacterManager.SelectedCharacter, location, marketOrders);
                            if (characterOrder.IsBuyOrder == true)
                            {
                                lock (buysLock)
                                {
                                    BuyOrdersCollection.Add(newRow);
                                }
                            }
                            else
                            {
                                lock (sellsLock)
                                {
                                    SellOrdersCollection.Add(newRow);
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
    }
}
