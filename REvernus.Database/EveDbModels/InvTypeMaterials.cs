namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvTypeMaterials
    {
        public long MaterialTypeId { get; set; }
        public long Quantity { get; set; }
        public long TypeId { get; set; }
    }
}