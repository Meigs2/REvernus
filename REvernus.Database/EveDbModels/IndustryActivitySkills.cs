namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivitySkills
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? SkillId { get; set; }
        public long? Level { get; set; }
    }
}
