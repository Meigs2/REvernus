namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class DgmTypeAttributes
    {
        public long AttributeId { get; set; }
        public long TypeId { get; set; }
        public double? ValueFloat { get; set; }
        public long? ValueInt { get; set; }
    }
}