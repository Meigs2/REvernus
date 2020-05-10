namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapConstellationJumps
    {
        public long? FromRegionId { get; set; }
        public long FromConstellationId { get; set; }
        public long ToConstellationId { get; set; }
        public long? ToRegionId { get; set; }
    }
}
