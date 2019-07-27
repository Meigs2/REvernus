using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using REvernus.Utilities;

namespace REvernus.ViewModels
{
    public class MarginToolViewModel
    {
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
                var orders = new List<ExportedOrderModel>();
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

                                orders.Add(order);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
