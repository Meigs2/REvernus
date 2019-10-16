using System;
using System.Collections.Generic;
using System.Text;

namespace REvernus.Models
{
    public class ExportedOrderModel
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
}
