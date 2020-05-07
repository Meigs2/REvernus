namespace REvernus.Database.EveDbModels
{
    public class ChrAncestries
    {
        public long AncestryId { get; set; }
        public string AncestryName { get; set; }
        public long? BloodlineId { get; set; }
        public string Description { get; set; }
        public long? Perception { get; set; }
        public long? Willpower { get; set; }
        public long? Charisma { get; set; }
        public long? Memory { get; set; }
        public long? Intelligence { get; set; }
        public long? IconId { get; set; }
        public string ShortDescription { get; set; }
    }
}
