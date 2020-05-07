namespace REvernus.Database.EveDbModels
{
    public partial class PlanetSchematicsTypeMap
    {
        public long SchematicId { get; set; }
        public long TypeId { get; set; }
        public long? Quantity { get; set; }
        public byte[] IsInput { get; set; }
    }
}
