namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class StaStations
    {
        public long? ConstellationId { get; set; }
        public long? CorporationId { get; set; }
        public double? DockingCostPerVolume { get; set; }
        public double? MaxShipVolumeDockable { get; set; }
        public long? OfficeRentalCost { get; set; }
        public long? OperationId { get; set; }
        public long? RegionId { get; set; }
        public double? ReprocessingEfficiency { get; set; }
        public long? ReprocessingHangarFlag { get; set; }
        public double? ReprocessingStationsTake { get; set; }
        public double? Security { get; set; }
        public long? SolarSystemId { get; set; }
        public long StationId { get; set; }
        public string StationName { get; set; }
        public long? StationTypeId { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
    }
}