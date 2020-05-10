namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CertSkills
    {
        public long? CertId { get; set; }
        public long? CertLevelInt { get; set; }
        public string CertLevelText { get; set; }
        public long? SkillId { get; set; }
        public long? SkillLevel { get; set; }
    }
}