namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapJumps
    {
        public long StargateId { get; set; }
        public long? DestinationId { get; set; }
    }
}
