namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class PlanetSchematics
    {
        public long SchematicId { get; set; }
        public string SchematicName { get; set; }
        public long? CycleTime { get; set; }
    }
}
