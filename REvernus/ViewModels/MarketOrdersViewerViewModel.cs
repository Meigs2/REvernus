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
using System.Media;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Threading;
using EVEStandard.Models.API;
using Gma.System.MouseKeyHook;
using ICSharpCode.SharpZipLib.Core;
using REvernus.Core.ESI;
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

        public DispatcherTimer AutoRefreshTimer { get; set; } = new DispatcherTimer();

        public bool AutoRefreshEnabled
        {
            get => _autoRefreshEnabled;
            set
            {
                if (value)
                {
                    AutoRefreshTimer.Start();
                }
                else
                {
                    AutoRefreshTimer.Stop();
                }

                SetProperty(ref _autoRefreshEnabled, value);
            }
        }   

        public uint RefreshMinutes
        {
            get => _refreshMinutes;
            set => SetProperty(ref _refreshMinutes, value);
        }

        public int SellOrdersActiveOrders
        {
            get => _sellOrdersActiveOrders;
            set => SetProperty(ref _sellOrdersActiveOrders, value);
        }

        public int BuyOrdersActiveOrders
        {
            get => _buyOrdersActiveOrders;
            set => SetProperty(ref _buyOrdersActiveOrders, value);
        }

        public string SellVolumeRemaining
        {
            get => _sellVolumeRemaining;
            set => SetProperty(ref _sellVolumeRemaining, value);
        }

        public string BuyVolumeRemaining
        {
            get => _buyVolumeRemaining;
            set => SetProperty(ref _buyVolumeRemaining, value);
        }

        public double SellTotalValue
        {
            get => _sellTotalValue;
            set => SetProperty(ref _sellTotalValue, value);
        }

        public double BuyTotalValue
        {
            get => _buyTotalValue;
            set => SetProperty(ref _buyTotalValue, value);
        }

        public double TotalInEscrow
        {
            get => _totalInEscrow;
            set => SetProperty(ref _totalInEscrow, value);
        }

        public double IskToCover
        {
            get => _iskToCover;
            set => SetProperty(ref _iskToCover, value);
        }

        private IKeyboardMouseEvents _keybindEvents = Hook.GlobalEvents();
        private int _sellsSelectedIndex;
        private object _sellsSelectedItem;
        private int _buysSelectedIndex;
        private object _buysSelectedItem;
        private uint _refreshMinutes = 5;
        private bool _autoRefreshEnabled = false;
        private int _sellOrdersActiveOrders;
        private int _buyOrdersActiveOrders;
        private string _sellVolumeRemaining = "0/0";
        private string _buyVolumeRemaining = "0/0";
        private double _sellTotalValue;
        private double _buyTotalValue;
        private double _totalInEscrow;
        private double _iskToCover;

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MarketOrdersViewerViewModel()
        {
            AutoRefreshTimer.Interval = TimeSpan.FromSeconds(App.Settings.MarketSettings.AutoUpdateTimer);
            AutoRefreshTimer.Tick += async (sender, e) => await LoadOrdersFromEsi();

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
                {Combination.FromString(App.Settings.HotkeySettings.MarketUpHotkey),  async () => await KeyBindMoveUp()},
                {Combination.FromString(App.Settings.HotkeySettings.MarketDownHotkey), async () => await KeyBindMoveDown()}
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
            try
            {
                ObservableCollection<MarketOrderInfoModel> selectedGrid = null;
                MarketOrderInfoModel currentItem = null;
                var isBuyCollection = false;
                var currentRowIndex = 0;

                if (SellsSelectedItem != null)
                {
                    selectedGrid = SellOrdersCollection;
                    currentItem = (MarketOrderInfoModel) SellsSelectedItem;
                    currentRowIndex = SellsSelectedIndex;
                }

                if (BuysSelectedItem != null)
                {
                    selectedGrid = BuyOrdersCollection;
                    currentItem = (MarketOrderInfoModel) BuysSelectedItem;
                    currentRowIndex = BuysSelectedIndex;
                    isBuyCollection = true;
                }

                if (selectedGrid == null || currentItem == null) return;

                var nextIndex = direction == Key.Up ? currentRowIndex - 1 : currentRowIndex + 1;

                if (nextIndex < 0 || nextIndex >= selectedGrid.Count)
                {
                    return;
                }

                if (isBuyCollection)
                {
                    BuysSelectedIndex = nextIndex;
                    currentItem = (MarketOrderInfoModel) BuysSelectedItem;
                }
                else
                {
                    SellsSelectedIndex = nextIndex;
                    currentItem = (MarketOrderInfoModel) SellsSelectedItem;
                }

                var character = CharacterManager.CharacterList.FirstOrDefault(c => c.CharacterName == currentItem.Owner);

                if (character != null)
                {
                    try
                    {
                        var dto = new AuthDTO
                        {
                            CharacterId = character.CharacterDetails.CharacterId,
                            Scopes = EVEStandard.Enumerations.Scopes.ESI_UI_OPEN_WINDOW_1,
                            AccessToken = character.AccessTokenDetails
                        };
                        await EsiData.EsiClient.UserInterface.OpenMarketDetailsV1Async(dto, currentItem.ItemId);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                Clipboard.SetText(Math.Round(currentItem.Order.IsBuyOrder == true ? (currentItem.BuyOrders[0].Price + .1) : (currentItem.SellOrders[0].Price - .1), 2, MidpointRounding.ToEven).ToString("N"));

                SystemSounds.Beep.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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

                SellOrdersActiveOrders = SellOrdersCollection.Count;
                BuyOrdersActiveOrders = BuyOrdersCollection.Count;

                SellTotalValue = SellOrdersCollection.Sum(o => (o.Price * o.VolumeRemaining));
                BuyTotalValue = BuyOrdersCollection.Sum(o => (o.Price * o.VolumeRemaining));

                SellVolumeRemaining = SellOrdersCollection.Sum(o => o.VolumeRemaining) + "/" + SellOrdersCollection.Sum(o => o.VolumeTotal);
                BuyVolumeRemaining = BuyOrdersCollection.Sum(o => o.VolumeRemaining) + "/" + BuyOrdersCollection.Sum(o => o.VolumeTotal);

                TotalInEscrow = 0.0;
                IskToCover = 0.0;
                foreach (var marketOrderInfoModel in BuyOrdersCollection)
                {
                    if (marketOrderInfoModel.Escrow == null) continue;

                    var escrow = (double) marketOrderInfoModel.Escrow;
                    TotalInEscrow += escrow;
                    IskToCover += marketOrderInfoModel.OrderValue - escrow;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
