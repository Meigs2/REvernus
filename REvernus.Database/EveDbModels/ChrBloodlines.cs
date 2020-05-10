﻿namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class ChrBloodlines
    {
        public long BloodlineId { get; set; }
        public string BloodlineName { get; set; }
        public long? Charisma { get; set; }
        public long? CorporationId { get; set; }
        public string Description { get; set; }
        public string FemaleDescription { get; set; }
        public long? IconId { get; set; }
        public long? Intelligence { get; set; }
        public string MaleDescription { get; set; }
        public long? Memory { get; set; }
        public long? Perception { get; set; }
        public long? RaceId { get; set; }
        public long? ShipTypeId { get; set; }
        public string ShortDescription { get; set; }
        public string ShortFemaleDescription { get; set; }
        public string ShortMaleDescription { get; set; }
        public long? Willpower { get; set; }
    }
}