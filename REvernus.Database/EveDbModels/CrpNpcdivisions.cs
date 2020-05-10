namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CrpNpcdivisions
    {
        public string Description { get; set; }
        public long DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string LeaderType { get; set; }
    }
}