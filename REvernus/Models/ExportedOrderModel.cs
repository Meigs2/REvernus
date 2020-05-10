namespace REvernus.Models
{
    using System;

    using JetBrains.Annotations;

    [PublicAPI]
    public class ExportedOrderModel
    {
        public DateTime DateIssued { get; set; }
        public int Duration { get; set; }
        public bool IsBuyOrder { get; set; }
        public int MinVolume { get; set; }
        public int NumJumpsAway { get; set; }
        public long OrderId { get; set; }
        public double Price { get; set; }
        public int Range { get; set; }
        public int RegionId { get; set; }
        public long StationId { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
        public int VolumeEntered { get; set; }
        public int VolumeRemaining { get; set; }
    }
}