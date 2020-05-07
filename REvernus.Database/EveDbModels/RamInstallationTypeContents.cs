namespace REvernus.Database.EveDbModels
{
    public partial class RamInstallationTypeContents
    {
        public long InstallationTypeId { get; set; }
        public long AssemblyLineTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
