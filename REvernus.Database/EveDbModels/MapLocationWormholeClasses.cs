namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapLocationWormholeClasses
    {
        public long LocationId { get; set; }
        public long? WormholeClassId { get; set; }
    }
}