namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class SkinMaterials
    {
        public long SkinMaterialId { get; set; }
        public long? DisplayNameId { get; set; }
        public long? MaterialSetId { get; set; }
    }
}
