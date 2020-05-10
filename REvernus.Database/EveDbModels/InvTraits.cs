namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    public class InvTraits
    {
        public double? Bonus { get; set; }
        public string BonusText { get; set; }
        public long? SkillId { get; set; }

        [PublicAPI]
        public long TraitId { get; set; }

        public long? TypeId { get; set; }
        public long? UnitId { get; set; }
    }
}