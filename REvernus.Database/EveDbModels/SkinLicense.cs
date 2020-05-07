namespace REvernus.Database.EveDbModels
{
    public partial class SkinLicense
    {
        public long LicenseTypeId { get; set; }
        public long? Duration { get; set; }
        public long? SkinId { get; set; }
    }
}
