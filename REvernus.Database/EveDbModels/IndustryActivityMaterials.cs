namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivityMaterials
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? MaterialTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
