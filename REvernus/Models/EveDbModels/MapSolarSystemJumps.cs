using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class MapSolarSystemJumps
    {
        public long? FromRegionId { get; set; }
        public long? FromConstellationId { get; set; }
        public long FromSolarSystemId { get; set; }
        public long ToSolarSystemId { get; set; }
        public long? ToConstellationId { get; set; }
        public long? ToRegionId { get; set; }
    }
}
