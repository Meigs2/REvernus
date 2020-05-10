namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapRegionJumps
    {
        public long FromRegionId { get; set; }
        public long ToRegionId { get; set; }
    }
}