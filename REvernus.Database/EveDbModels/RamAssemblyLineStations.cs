namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamAssemblyLineStations
    {
        public long AssemblyLineTypeId { get; set; }
        public long? OwnerId { get; set; }
        public long? Quantity { get; set; }
        public long? RegionId { get; set; }
        public long? SolarSystemId { get; set; }
        public long StationId { get; set; }
        public long? StationTypeId { get; set; }
    }
}