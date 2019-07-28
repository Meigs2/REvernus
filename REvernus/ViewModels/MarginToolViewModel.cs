using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Models;
using REvernus.Utilities;

namespace REvernus.ViewModels
{
    public class MarginToolViewModel : BindableBase
    {
        #region Margin Tool Bindings

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

        private double _brokerNpc = 0.027;
        public double BrokerNpc
        {
            get => _brokerNpc;
            set => SetProperty(ref _brokerNpc, value);
        }

        private double _brokerCitadel = 0.003;
        public double BrokerCitadel
        {
            get => _brokerCitadel;
            set => SetProperty(ref _brokerCitadel, value);
        }

        private double _salesTax = 0.012;
        public double SalesTax
        {
            get => _salesTax;
            set => SetProperty(ref _salesTax, value);
        }

        private string _profit = "0.00";
        public string Profit
        {
            get => _profit;
            set => SetProperty(ref _profit, value);
        }

        private string _buyCopyPrice;
        public string BuyCopyPrice
        {
            get => _buyCopyPrice;
            set => SetProperty(ref _buyCopyPrice, value);
        }

        private string _sellCopyPrice;
        public string SellCopyPrice
        {
            get => _buyCopyPrice;
            set => SetProperty(ref _sellCopyPrice, value);
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
                                order.Price = double.Parse(values[0]);
                                order.VolumeRemaining = Convert.ToInt32(Math.Floor(Convert.ToDouble(values[1])));
                                order.TypeId = int.Parse(values[2]);
                                order.Range = int.Parse(values[3]);
                                order.OrderId = long.Parse(values[4]);
                                order.VolumeEntered = int.Parse(values[5]);
                                order.MinVolume = int.Parse(values[6]);
                                order.IsBuyOrder = bool.Parse(values[7]);
                                order.DateIssued = DateTime.Parse(values[8]);
                                order.Duration = int.Parse(values[9]);
                                order.StationId = long.Parse(values[10]);
                                order.RegionId = int.Parse(values[11]);
                                order.SystemId = int.Parse(values[12]);
                                order.NumJumpsAway = int.Parse(values[13]);

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
                var filteredOrders = Orders.Where(o => o.NumJumpsAway < 1).ToList();
                var filteredSellOrders = filteredOrders.Where(o => !o.IsBuyOrder).ToList();
                var filteredBuyOrders = filteredOrders.Where(o => o.IsBuyOrder).ToList();

                // Calculate margin
                var bestSell = filteredSellOrders[0].Price - 0.10;
                var bestBuy = filteredBuyOrders[0].Price + 0.10;

                Margin = GetMargin(bestSell, bestBuy).ToString("P");
                Markup = GetMarkup(bestSell, bestBuy).ToString("P");
                Profit = GetProfit(bestSell, bestBuy).ToString("N");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
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
            var costs = (sellPrice * SalesTax) + (sellPrice * BrokerNpc) + (buyPrice * BrokerNpc) + buyPrice;
            var revenue = sellPrice;
            return revenue - costs;
        }

        public double GetSellPrice(double sellPrice)
        {
            return ( sellPrice * ( 1.0 - SalesTax) ) - (sellPrice * BrokerNpc);
        }

        public double GetBuyPrice(double buyPrice)
        {
            return buyPrice + (buyPrice * BrokerNpc);
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
