using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class MapLandmarks
    {
        public long LandmarkId { get; set; }
        public string LandmarkName { get; set; }
        public string Description { get; set; }
        public long? LocationId { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public long? IconId { get; set; }
    }
}
