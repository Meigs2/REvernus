namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CrpNpccorporationDivisions
    {
        public long CorporationId { get; set; }
        public long DivisionId { get; set; }
        public long? Size { get; set; }
    }
}
