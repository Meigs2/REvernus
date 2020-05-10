namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class PlanetSchematicsPinMap
    {
        public long SchematicId { get; set; }
        public long PinTypeId { get; set; }
    }
}
