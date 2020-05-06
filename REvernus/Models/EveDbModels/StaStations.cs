namespace REvernus.Models.EveDbModels
{
    public partial class StaStations
    {
        public long StationId { get; set; }
        public double? Security { get; set; }
        public double? DockingCostPerVolume { get; set; }
        public double? MaxShipVolumeDockable { get; set; }
        public long? OfficeRentalCost { get; set; }
        public long? OperationId { get; set; }
        public long? StationTypeId { get; set; }
        public long? CorporationId { get; set; }
        public long? SolarSystemId { get; set; }
        public long? ConstellationId { get; set; }
        public long? RegionId { get; set; }
        public string StationName { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? ReprocessingEfficiency { get; set; }
        public double? ReprocessingStationsTake { get; set; }
        public long? ReprocessingHangarFlag { get; set; }
    }
}
