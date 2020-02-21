using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class ChrFactions
    {
        public long FactionId { get; set; }
        public string FactionName { get; set; }
        public string Description { get; set; }
        public long? RaceIds { get; set; }
        public long? SolarSystemId { get; set; }
        public long? CorporationId { get; set; }
        public double? SizeFactor { get; set; }
        public long? StationCount { get; set; }
        public long? StationSystemCount { get; set; }
        public long? MilitiaCorporationId { get; set; }
        public long? IconId { get; set; }
    }
}
