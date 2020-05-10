namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapSolarSystemJumps
    {
        public long? FromConstellationId { get; set; }
        public long? FromRegionId { get; set; }
        public long FromSolarSystemId { get; set; }
        public long? ToConstellationId { get; set; }
        public long? ToRegionId { get; set; }
        public long ToSolarSystemId { get; set; }
    }
}