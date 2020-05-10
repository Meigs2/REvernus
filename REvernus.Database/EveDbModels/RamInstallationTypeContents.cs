namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamInstallationTypeContents
    {
        public long AssemblyLineTypeId { get; set; }
        public long InstallationTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}