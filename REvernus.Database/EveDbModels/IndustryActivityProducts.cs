namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivityProducts
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? ProductTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
