namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryBlueprints
    {
        public long TypeId { get; set; }
        public long? MaxProductionLimit { get; set; }
    }
}
