namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class Skins
    {
        public string InternalName { get; set; }
        public long SkinId { get; set; }
        public long? SkinMaterialId { get; set; }
    }
}