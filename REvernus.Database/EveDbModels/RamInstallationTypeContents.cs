namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamInstallationTypeContents
    {
        public long InstallationTypeId { get; set; }
        public long AssemblyLineTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
