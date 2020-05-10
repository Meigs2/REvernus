namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryBlueprints
    {
        public long? MaxProductionLimit { get; set; }
        public long TypeId { get; set; }
    }
}