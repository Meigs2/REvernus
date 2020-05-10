namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapJumps
    {
        public long? DestinationId { get; set; }
        public long StargateId { get; set; }
    }
}