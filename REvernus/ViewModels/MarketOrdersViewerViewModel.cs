using EVEStandard.Models;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using EVEStandard.Models.API;
using Gma.System.MouseKeyHook;
using REvernus.Core.ESI;
using REvernus.Models;
using REvernus.Utilities.Extensions;
using Clipboard = System.Windows.Clipboard;
using Market = REvernus.Utilities.Esi.Market;
using Status = REvernus.Utilities.Status;

namespace REvernus.ViewModels
{
    using REvernus.Utilites;

    public class MarketOrdersViewerViewModel : BindableBase
    {
        public ObservableCollection<MarketOrderInfoModel> SellOrdersCollection { get; set; } = new ObservableCollection<MarketOrderInfoModel>();
        public ObservableCollection<MarketOrderInfoModel> BuyOrdersCollection { get; set; } = new ObservableCollection<MarketOrderInfoModel>();
        public Dictionary<string, List<CharacterMarketOrder>> CharacterToOrders { get; set; } = new Dictionary<string, List<CharacterMarketOrder>>();
        public Dictionary<long, Dictionary<int, List<MarketOrder>>> OrdersList { get; set; }

        #region Bindings
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        #endregion

        #region Delegates
        public DelegateCommand GetOrdersEsiCommand { get; set; }

        public DelegateCommand GetOrdersFilesCommand { get; set; }
        #endregion

        #region Hotkeys
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
                {Combination.FromString(App.Settings.MarketOrdersTabSettings.MarketUpHotkey),  async () => await KeyBindMoveUp()},
                {Combination.FromString(App.Settings.MarketOrdersTabSettings.MarketDownHotkey), async () => await KeyBindMoveDown()}
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
                if (App.Settings.MarketOrdersTabSettings.ResetRefreshTimerOnPriceCopy && AutoRefreshEnabled)
                {
                    AutoRefreshTimer.Stop();
                    AutoRefreshTimer.Start();
                }

                ObservableCollection<MarketOrderInfoModel> selectedGrid = null;
                MarketOrderInfoModel currentItem = null;
                var isBuyCollection = false;
                var currentRowIndex = 0;

                if (SellsSelectedItem != null)
                {
                    selectedGrid = SellOrdersCollection;
                    currentItem = (MarketOrderInfoModel)SellsSelectedItem;
                    currentRowIndex = SellsSelectedIndex;
                }

                if (BuysSelectedItem != null)
                {
                    selectedGrid = BuyOrdersCollection;
                    currentItem = (MarketOrderInfoModel)BuysSelectedItem;
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
                    currentItem = (MarketOrderInfoModel)BuysSelectedItem;
                }
                else
                {
                    SellsSelectedIndex = nextIndex;
                    currentItem = (MarketOrderInfoModel)SellsSelectedItem;
                }

                var character = App.CharacterManager.CharacterList.FirstOrDefault(c => c.CharacterName == currentItem.Owner);

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
                        if (App.Settings.MarketOrdersTabSettings.ShowInEveClient == true)
                        {
                            await EsiData.EsiClient.UserInterface.OpenMarketDetailsV1Async(dto, currentItem.ItemId);
                        }

                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                Clipboard.SetText(Math.Round(currentItem.Order.IsBuyOrder == true ? (currentItem.BuyOrders[0].Price + App.Settings.MarketSettings.GetUndercut) :
                    (currentItem.SellOrders[0].Price - App.Settings.MarketSettings.GetUndercut), 2, MidpointRounding.ToEven).ToString("F"));

                if (App.Settings.MarketOrdersTabSettings.PlayOrderChangedSound) SystemSounds.Beep.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        #endregion

        #region Refresh Timer Things
        public DispatcherTimer AutoRefreshTimer { get; set; } = new DispatcherTimer();

        public bool AutoRefreshEnabled
        {
            get => App.Settings.MarketOrdersTabSettings.AutoUpdateTimerEnabled;
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
                App.Settings.MarketOrdersTabSettings.AutoUpdateTimerEnabled = value;
                SetProperty(ref _autoRefreshEnabled, value);
            }
        }

        #endregion

        private IKeyboardMouseEvents _keybindEvents = Hook.GlobalEvents();
        private int _sellsSelectedIndex;
        private object _sellsSelectedItem;
        private int _buysSelectedIndex;
        private object _buysSelectedItem;
        private bool _autoRefreshEnabled;
        private int _sellOrdersActiveOrders;
        private int _buyOrdersActiveOrders;
        private string _sellVolumeRemaining = "0/0";
        private string _buyVolumeRemaining = "0/0";
        private double _sellTotalValue;
        private double _buyTotalValue;
        private double _totalInEscrow;
        private double _iskToCover;
        private readonly object _buysLock = new object();
        private readonly object _sellsLock = new object();
        private bool _isEnabled = true;

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MarketOrdersViewerViewModel()
        {
            AutoRefreshTimer.Interval = TimeSpan.FromSeconds(App.Settings.MarketOrdersTabSettings.AutoUpdateMintues);
            AutoRefreshTimer.Tick += async (sender, e) => await LoadOrdersFromEsi();

            GetOrdersEsiCommand = new DelegateCommand(async () => await LoadOrdersFromEsi());
            GetOrdersFilesCommand = new DelegateCommand(async () => await LoadOrdersFromFiles());

            SubscribeHotKeys();
            AppDomain.CurrentDomain.ProcessExit += UnsubscribeHotKeys;
            SettingsManagerViewModel.SettingsSaved += (sender, args) => SubscribeHotKeys();
            SettingsManagerViewModel.SettingsSaved += (sender, args) => InitializeRefreshTimer();

            BindingOperations.EnableCollectionSynchronization(BuyOrdersCollection, _buysLock);
            BindingOperations.EnableCollectionSynchronization(SellOrdersCollection, _sellsLock);
        }

        private void InitializeRefreshTimer()
        {
            AutoRefreshTimer.Interval = TimeSpan.FromMinutes(App.Settings.MarketOrdersTabSettings.AutoUpdateMintues);
            AutoRefreshTimer.IsEnabled = AutoRefreshEnabled;
        }
        
        private async Task LoadOrdersFromFiles()
        {
            var directory = new DirectoryInfo(Paths.EveMarketLogsFolderPath);
            var mostRecentOrderFile = directory.GetFiles()
                .OrderByDescending(f => f.LastWriteTime).FirstOrDefault(f => f.Name.Contains("My Orders-"));

            if (mostRecentOrderFile != null)
            {
                var orders = File.ReadAllLines(mostRecentOrderFile.FullName).Skip(1).Select(v => new CharacterMarketOrder().FromCsv(v)).ToList();
                var name = "";
                try
                {
                    using var reader = new StreamReader(mostRecentOrderFile.FullName);
                    reader.ReadLine();
                    var line = reader.ReadLine();
                    if (line != null) name = line.Split(',')[3];
                    reader.Close();
                }
                catch (Exception)
                {
                    // ignored
                }

                await UpdateOrders(orders, name);
            }
        }

        private async Task LoadOrdersFromEsi()
        {
            var characterOrders = await App.CharacterManager.SelectedCharacter.GetCharacterMarketOrdersAsync();
            var characterName = App.CharacterManager.SelectedCharacter.CharacterName;
            await UpdateOrders(characterOrders, characterName);
        }

        private async Task UpdateOrders(List<CharacterMarketOrder> characterOrders, string characterName)
        {
            IsEnabled = false;
            if (!CharacterToOrders.ContainsKey(characterName))
            {
                CharacterToOrders.TryAdd(characterName, new List<CharacterMarketOrder>());
            }

            // All character orders are unique unless updated. Every time we provide
            // UpdateOrders with a non-empty list, we are telling REvernus to update,
            // add, or remove existing orders. We then work with this list of orders
            // that we keep internally. In future releases we will keep track of these
            // in the user database for loading of orders later.

            var toBeRemoved = CharacterToOrders[characterName].Where(o => !characterOrders.Select(n => n.OrderId).Contains(o.OrderId)).ToList();
            var toBeAdded = characterOrders.Where(n => !CharacterToOrders[characterName].Select(o => o.OrderId).Contains(n.OrderId)).ToList();
            var toBeUpdated = CharacterToOrders[characterName].Where(o => characterOrders.Select(n => n.OrderId).Contains(o.OrderId)).ToList();

            foreach (var characterMarketOrder in toBeRemoved)
            {
                CharacterToOrders[characterName].Remove(characterMarketOrder);
            }

            foreach (var characterMarketOrder in toBeAdded)
            {
                CharacterToOrders[characterName].Add(characterMarketOrder);
            }

            foreach (var oldOrder in toBeUpdated)
            {
                var newOrder = characterOrders.First(o => o.OrderId == oldOrder.OrderId);
                if (newOrder.Issued >= oldOrder.Issued) continue;

                var index = CharacterToOrders[characterName].IndexOf(oldOrder);
                CharacterToOrders[characterName][index] = characterOrders.First(o => o.OrderId == oldOrder.OrderId);
            }

            var locations = new HashSet<long>();
            var typeIds = new HashSet<int>();

            foreach (var characterMarketOrder in characterOrders)
            {
                locations.Add(characterMarketOrder.LocationId);
                typeIds.Add(characterMarketOrder.TypeId);
            }

            OrdersList = new Dictionary<long, Dictionary<int, List<MarketOrder>>>();

            foreach (var location in locations)
            {
                var orders = await Market.GetOrdersInStructure(location, typeIds.ToList());
                OrdersList.TryAdd(location, orders);
            }

            await UpdateData(characterName);

            IsEnabled = true;
        }

        private async Task UpdateData(string characterName = "")
        {
            var taskList = new List<Task>();

            if (characterName == "")
            {
                foreach (var charName in CharacterToOrders.Keys)
                {
                    foreach (var characterOrder in CharacterToOrders[charName])
                    {
                        using var a = Status.GetNewStatusHandle();
                        // If something didn't go wrong along the way, we now have all the public orders in the location of our current order
                        if (!OrdersList.TryGetValue(characterOrder.LocationId, out var idsToOrders)) continue;
                        if (!idsToOrders.TryGetValue(characterOrder.TypeId, out var marketOrders)) continue;

                        var location = StructureManager.GetStructureName(characterOrder.LocationId);
                        var existingOrder =
                            BuyOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId) ??
                            SellOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId);

                        if (existingOrder != null)
                        {
                            existingOrder.Order = characterOrder;
                            existingOrder.MarketOrders = marketOrders;
                            existingOrder.LocationName = location;
                            return;
                        }

                        var newOrder = new MarketOrderInfoModel(characterOrder,
                            App.CharacterManager.CharacterList.FirstOrDefault(c => c.CharacterName == characterName),
                            location, marketOrders);
                        if (characterOrder.IsBuyOrder == true)
                        {
                            lock (_buysLock)
                            {
                                BuyOrdersCollection.Add(newOrder);
                            }
                        }
                        else
                        {
                            lock (_sellsLock)
                            {
                                SellOrdersCollection.Add(newOrder);
                            }
                        }
                    }
                }
            }
            else
            {
                var sellRemove = SellOrdersCollection.Where(o => o.Owner != characterName).ToList();
                foreach (var item in sellRemove)
                {
                    SellOrdersCollection.Remove(item);
                }

                var buyRemove = BuyOrdersCollection.Where(o => o.Owner != characterName).ToList();
                foreach (var item in buyRemove)
                {
                    BuyOrdersCollection.Remove(item);
                }

                foreach (var characterOrder in CharacterToOrders[characterName])
                {
                    using var a = Status.GetNewStatusHandle();
                    // If something didn't go wrong along the way, we now have all the public orders in the location of our current order
                    if (!OrdersList.TryGetValue(characterOrder.LocationId, out var idsToOrders)) continue;
                    if (!idsToOrders.TryGetValue(characterOrder.TypeId, out var marketOrders)) continue;

                    var location = StructureManager.GetStructureName(characterOrder.LocationId);
                    var existingOrder =
                        BuyOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId) ??
                        SellOrdersCollection.FirstOrDefault(o => o.Order.OrderId == characterOrder.OrderId);

                    if (existingOrder != null)
                    {
                        existingOrder.Order = characterOrder;
                        existingOrder.MarketOrders = marketOrders;
                        existingOrder.LocationName = location;
                        return;
                    }

                    var newOrder = new MarketOrderInfoModel(characterOrder,
                        App.CharacterManager.CharacterList.FirstOrDefault(c => c.CharacterName == characterName),
                        location, marketOrders);
                    if (characterOrder.IsBuyOrder == true)
                    {
                        lock (_buysLock)
                        {
                            BuyOrdersCollection.Add(newOrder);
                        }
                    }
                    else
                    {
                        lock (_sellsLock)
                        {
                            SellOrdersCollection.Add(newOrder);
                        }
                    }
                }
            }


            await Task.WhenAll(taskList);

            // Fill out info in tab.

            SellOrdersActiveOrders = SellOrdersCollection.Count;
            BuyOrdersActiveOrders = BuyOrdersCollection.Count;

            SellTotalValue = SellOrdersCollection.Sum(o => (o.Price * o.VolumeRemaining));
            BuyTotalValue = BuyOrdersCollection.Sum(o => (o.Price * o.VolumeRemaining));

            SellVolumeRemaining = SellOrdersCollection.Sum(o => o.VolumeRemaining) + "/" +
                                  SellOrdersCollection.Sum(o => o.VolumeTotal);
            BuyVolumeRemaining = BuyOrdersCollection.Sum(o => o.VolumeRemaining) + "/" +
                                 BuyOrdersCollection.Sum(o => o.VolumeTotal);

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
    }
}
