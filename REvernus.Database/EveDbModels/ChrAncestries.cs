namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class ChrAncestries
    {
        public long AncestryId { get; set; }
        public string AncestryName { get; set; }
        public long? BloodlineId { get; set; }
        public long? Charisma { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
        public long? Intelligence { get; set; }
        public long? Memory { get; set; }
        public long? Perception { get; set; }
        public string ShortDescription { get; set; }
        public long? Willpower { get; set; }
    }
}