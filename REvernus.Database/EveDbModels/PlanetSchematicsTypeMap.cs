namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class PlanetSchematicsTypeMap
    {
        public long SchematicId { get; set; }
        public long TypeId { get; set; }
        public long? Quantity { get; set; }
        public byte[] IsInput { get; set; }
    }
}
