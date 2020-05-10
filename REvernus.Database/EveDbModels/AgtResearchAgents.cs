namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class AgtResearchAgents
    {
        public long AgentId { get; set; }
        public long TypeId { get; set; }
    }
}