namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class SkinLicense
    {
        public long LicenseTypeId { get; set; }
        public long? Duration { get; set; }
        public long? SkinId { get; set; }
    }
}
