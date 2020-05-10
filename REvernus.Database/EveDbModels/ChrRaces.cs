namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class ChrRaces
    {
        public long RaceId { get; set; }
        public string RaceName { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
        public string ShortDescription { get; set; }
    }
}
