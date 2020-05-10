namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class PlanetSchematicsPinMap
    {
        public long PinTypeId { get; set; }
        public long SchematicId { get; set; }
    }
}