using Prism.Mvvm;
using Prism.Commands;
using REvernus.Core;
using REvernus.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace REvernus.ViewModels
{
    public class MarginToolViewModel : BindableBase
    {
        #region Margin Tool Bindings

        private DataTable _tensDataTable = new DataTable();
        public DataTable TensDataTable
        {
            get => _tensDataTable;
            set => SetProperty(ref _tensDataTable, value);
        }

        private DataTable _fivesDataTable = new DataTable();
        public DataTable FivesDataTable
        {
            get => _fivesDataTable;
            set => SetProperty(ref _fivesDataTable, value);
        }

        private string _itemName = "Export Item Market Data In-Game";
        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        private string _margin = "0.00%";
        public string Margin
        {
            get => _margin;
            set => SetProperty(ref _margin, value);
        }

        private string _markup = "0.00%";
        public string Markup
        {
            get => _markup;
            set => SetProperty(ref _markup, value);
        }
        private string _profit = "0.00";
        public string Profit
        {
            get => _profit;
            set => SetProperty(ref _profit, value);
        }

        private string _revenue = "0";
        public string Revenue
        {
            get => _revenue;
            set => SetProperty(ref _revenue, value);
        }

        private string _costs = "0";
        public string Costs
        {
            get => _costs;
            set => SetProperty(ref _costs, value);
        }

        private string _buyout = "0";
        public string Buyout
        {
            get => _buyout;
            set => SetProperty(ref _buyout, value);
        }

        private string _numBuyOrders = "0";
        public string NumBuyOrders
        {
            get => _numBuyOrders;
            set => SetProperty(ref _numBuyOrders, value);
        }

        private string _numSellOrders = "0";
        public string NumSellOrders
        {
            get => _numSellOrders;
            set => SetProperty(ref _numSellOrders, value);
        }


        private string _sellOrderFulfillment = "0/0";
        public string SellOrderFulfillment
        {
            get => _sellOrderFulfillment;
            set => SetProperty(ref _sellOrderFulfillment, value);
        }

        private string _buyOrderFulfillment = "0/0";
        public string BuyOrderFulfillment
        {
            get => _buyOrderFulfillment;
            set => SetProperty(ref _buyOrderFulfillment, value);
        }

        private uint _jumpsOut;
        public uint JumpsOut
        {
            get => App.Settings.MarginToolSettings.JumpsOut;
            set
            {
                SetProperty(ref _jumpsOut, value);
                App.Settings.MarginToolSettings.JumpsOut = value;
            }
        }

        private double _buyBroker = 0.05;
        public double BuyBroker
        {
            get => _buyBroker;
            set
            {
                SetProperty(ref _buyBroker, value);
                UpdateMarginInformation(_sellPrice, _buyPrice);
            }
        }

        private double _sellBroker = 0.05;
        public double SellBroker
        {
            get => _sellBroker;
            set
            {
                SetProperty(ref _sellBroker, value);
                UpdateMarginInformation(_sellPrice, _buyPrice);
            }
        }

        private double _salesTax = 0.05;
        public double SalesTax
        {
            get => _salesTax;
            set
            {
                SetProperty(ref _salesTax, value);
                UpdateMarginInformation(_sellPrice, _buyPrice);
            }
        }

        private double _buyPrice;
        private string _buyCopyPrice;
        public string BuyCopyPrice
        {
            get => _buyCopyPrice;
            set
            {
                try
                {
                    var parsedPrice = double.Parse(value);
                    _buyPrice = parsedPrice;
                }
                catch (Exception)
                {
                    SetProperty(ref _sellCopyPrice, "");
                    return;
                }

                UpdateMarginInformation(_sellPrice, _buyPrice);

                SetProperty(ref _buyCopyPrice, _buyPrice.ToString("N"));
            }
        }

        private double _sellPrice;
        private string _sellCopyPrice;
        public string SellCopyPrice
        {
            get => _sellCopyPrice;
            set
            {
                try
                {
                    var parsedPrice = double.Parse(value);
                    _sellPrice = parsedPrice;
                }
                catch (Exception)
                {
                    SetProperty(ref _sellCopyPrice, "");
                    return;
                }

                UpdateMarginInformation(_sellPrice, _buyPrice);

                SetProperty(ref _sellCopyPrice, _sellPrice.ToString("N"));
            }
        }

        private CopyEnum _selectedEnum = CopyEnum.None;
        public CopyEnum SelectedEnum
        {
            get => _selectedEnum;
            set
            {
                SetProperty(ref _selectedEnum, value);
                switch (value)
                {
                    case CopyEnum.Sell:
                        SellPriceClipboardCopy();
                        break;
                    case CopyEnum.Buy:
                        BuyPriceClipboardCopy();
                        break;
                    case CopyEnum.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public enum CopyEnum
        {
            None,
            Sell,
            Buy
        }

        #endregion

        private List<ExportedOrderModel> Orders = new List<ExportedOrderModel>();

        private FileSystemWatcher _watcher;

        public MarginToolViewModel()
        {
            _watcher = new FileSystemWatcher()
            {
                Path = Paths.EveMarketLogsFolderPath,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime,
                IncludeSubdirectories = true
            };
            _watcher.Created += WatcherOnChanged;
            _watcher.EnableRaisingEvents = true;

            BuyCopyCommand = new DelegateCommand(BuyPriceClipboardCopy);
            SellCopyCommand = new DelegateCommand(SellPriceClipboardCopy);

            // Define SampleDataTables
            var tempTable = new DataTable();
            tempTable.Columns.AddRange(new List<DataColumn>()
            {
                new DataColumn("Volume", typeof(string)),
                new DataColumn("Cost", typeof(string)),
                new DataColumn("Profit", typeof(string))
            }.ToArray());

            TensDataTable = tempTable.Clone();
            FivesDataTable = tempTable.Clone();

            JumpsOut = App.Settings.MarginToolSettings.JumpsOut;
        }

        private void WatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                var currentChar = CharacterManager.SelectedCharacter;
                Orders.Clear();
                using (var file = File.Open(e.FullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (var reader = new StreamReader(file))
                    {

                        while (!reader.EndOfStream)
                        {
                            try
                            {
                                var values = reader.ReadLine().Split(',');
                                var order = new ExportedOrderModel();
                                order.Price = double.Parse(values[0], CultureInfo.InvariantCulture);
                                order.VolumeRemaining = Convert.ToInt32(Math.Floor(Convert.ToDouble(values[1])), CultureInfo.InvariantCulture);
                                order.TypeId = int.Parse(values[2], CultureInfo.InvariantCulture);
                                order.Range = int.Parse(values[3], CultureInfo.InvariantCulture);
                                order.OrderId = long.Parse(values[4], CultureInfo.InvariantCulture);
                                order.VolumeEntered = int.Parse(values[5], CultureInfo.InvariantCulture);
                                order.MinVolume = int.Parse(values[6], CultureInfo.InvariantCulture);
                                order.IsBuyOrder = bool.Parse(values[7]);
                                order.DateIssued = DateTime.Parse(values[8], CultureInfo.InvariantCulture);
                                order.Duration = int.Parse(values[9], CultureInfo.InvariantCulture);
                                order.StationId = long.Parse(values[10], CultureInfo.InvariantCulture);
                                order.RegionId = int.Parse(values[11], CultureInfo.InvariantCulture);
                                order.SystemId = int.Parse(values[12], CultureInfo.InvariantCulture);
                                order.NumJumpsAway = int.Parse(values[13], CultureInfo.InvariantCulture);

                                Orders.Add(order);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }

                // Filter results
                var filteredOrders = Orders.Where(o => o.NumJumpsAway <= JumpsOut).ToList();
                var filteredSellOrders = filteredOrders.Where(o => !o.IsBuyOrder).ToList();
                var filteredBuyOrders = filteredOrders.Where(o => o.IsBuyOrder).ToList();

                // Calculate margin
                _sellPrice = 0.0;
                _buyPrice = 0.0;

                if (filteredSellOrders.ElementAtOrDefault(0) != null)
                {
                    _sellPrice = filteredSellOrders[0].Price - 0.01;
                }
                if (filteredBuyOrders.ElementAtOrDefault(0) != null)
                {
                    _buyPrice = filteredBuyOrders[0].Price + 0.01;
                }

                ItemName = e.Name.Split('-')[1];
                Buyout = filteredSellOrders.Sum(o => o.Price * o.VolumeRemaining).ToString("N");
                NumBuyOrders = filteredBuyOrders.Count.ToString();
                NumSellOrders = filteredSellOrders.Count.ToString();

                BuyOrderFulfillment =
                    $"{filteredBuyOrders.Sum(o => o.VolumeEntered - o.VolumeRemaining)}/{filteredBuyOrders.Sum(o => o.VolumeEntered)}";
                SellOrderFulfillment =
                    $"{filteredSellOrders.Sum(o => o.VolumeEntered - o.VolumeRemaining)}/{filteredSellOrders.Sum(o => o.VolumeEntered)}";

                switch (SelectedEnum)
                {
                    case CopyEnum.Sell:
                        SellPriceClipboardCopy();
                        break;
                    case CopyEnum.Buy:
                        BuyPriceClipboardCopy();
                        break;
                    case CopyEnum.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SelectedEnum), SelectedEnum, null);
                }

                SellCopyPrice = _sellPrice.ToString("N");
                BuyCopyPrice = _buyPrice.ToString("N");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void UpdateMarginInformation(double bestSell, double bestBuy)
        {
            Margin = GetMargin(bestSell, bestBuy).ToString("P");
            Markup = GetMarkup(bestSell, bestBuy).ToString("P");

            double profit = GetProfit(bestSell, bestBuy);
            Profit = profit.ToString("N");

            Revenue = bestSell.ToString("N");
            double costs = GetCosts(bestSell, bestBuy);
            Costs = costs.ToString("N");

            var tempTensDataTable = TensDataTable.Clone();
            var tempFivesDataTable = FivesDataTable.Clone();

            for (int i = 0; i < 7; i++)
            {
                var newTensRow = tempTensDataTable.NewRow();
                var newFivesRow = tempFivesDataTable.NewRow();

                var multiplier = Math.Pow(10, i);

                newTensRow["Volume"] = multiplier.ToString("N");
                newTensRow["Cost"] = ((costs * multiplier)/1000000).ToString("N") + "M";
                newTensRow["Profit"] = ((profit * multiplier)/1000000).ToString("N") + "M";

                newFivesRow["Volume"] = (multiplier * 5).ToString("N");
                newFivesRow["Cost"] = ((costs * multiplier * 5)/1000000).ToString("N") + "M";
                newFivesRow["Profit"] = ((profit * multiplier * 5)/1000000).ToString("N") + "M";

                tempTensDataTable.Rows.Add(newTensRow);
                tempFivesDataTable.Rows.Add(newFivesRow);
            }

            TensDataTable = tempTensDataTable;
            FivesDataTable = tempFivesDataTable;
        }

        public double GetMargin(double sellPrice, double buyPrice)
        {
            var realSell = GetSellPrice(sellPrice);
            var realBuy = GetBuyPrice(buyPrice);

            return ((realSell - realBuy) / realSell);
        }

        public double GetMarkup(double sellPrice, double buyPrice)
        {
            var realSell = GetSellPrice(sellPrice);
            var realBuy = GetBuyPrice(buyPrice);

            return ((realSell - realBuy) / realBuy);
        }

        public double GetProfit(double sellPrice, double buyPrice)
        {
            var costs = GetCosts(sellPrice, buyPrice);
            var revenue = sellPrice;
            return revenue - costs;
        }

        private double GetCosts(double sellPrice, double buyPrice)
        {
            return (sellPrice * SalesTax) + (sellPrice * SellBroker) + (buyPrice * BuyBroker) + buyPrice;
        }

        public double GetSellPrice(double sellPrice)
        {
            return (sellPrice * (1.0 - SalesTax)) - (sellPrice * SellBroker);
        }

        public double GetBuyPrice(double buyPrice)
        {
            return buyPrice + (buyPrice * BuyBroker);
        }

        public DelegateCommand BuyCopyCommand { get; set; }
        private void BuyPriceClipboardCopy()
        {
            try
            {
                Clipboard.SetText(BuyCopyPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public DelegateCommand SellCopyCommand { get; set; }
        private void SellPriceClipboardCopy()
        {
            try
            {
                Clipboard.SetText(SellCopyPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

class ExportedOrderModel
{
    public double Price { get; set; }
    public int VolumeRemaining { get; set; }
    public int TypeId { get; set; }
    public int Range { get; set; }
    public long OrderId { get; set; }
    public int VolumeEntered { get; set; }
    public int MinVolume { get; set; }
    public bool IsBuyOrder { get; set; }
    public DateTime DateIssued { get; set; }
    public int Duration { get; set; }
    public long StationId { get; set; }
    public int RegionId { get; set; }
    public int SystemId { get; set; }
    public int NumJumpsAway { get; set; }
}
