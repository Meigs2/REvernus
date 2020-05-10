namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivityRaces
    {
        public long? ActivityId { get; set; }
        public long? ProductTypeId { get; set; }
        public long? RaceId { get; set; }
        public long? TypeId { get; set; }
    }
}