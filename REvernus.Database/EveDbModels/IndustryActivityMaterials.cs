namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivityMaterials
    {
        public long? ActivityId { get; set; }
        public long? MaterialTypeId { get; set; }
        public long? Quantity { get; set; }
        public long? TypeId { get; set; }
    }
}