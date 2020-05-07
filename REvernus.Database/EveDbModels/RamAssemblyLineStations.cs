namespace REvernus.Database.EveDbModels
{
    public partial class RamAssemblyLineStations
    {
        public long StationId { get; set; }
        public long AssemblyLineTypeId { get; set; }
        public long? Quantity { get; set; }
        public long? StationTypeId { get; set; }
        public long? OwnerId { get; set; }
        public long? SolarSystemId { get; set; }
        public long? RegionId { get; set; }
    }
}
