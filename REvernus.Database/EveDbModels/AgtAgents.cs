namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class AgtAgents
    {
        public long AgentId { get; set; }
        public long? DivisionId { get; set; }
        public long? CorporationId { get; set; }
        public long? LocationId { get; set; }
        public long? Level { get; set; }
        public long? Quality { get; set; }
        public long? AgentTypeId { get; set; }
        public byte[] IsLocator { get; set; }
    }
}
