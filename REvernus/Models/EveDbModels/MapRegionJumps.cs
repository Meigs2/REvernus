using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class MapRegionJumps
    {
        public long FromRegionId { get; set; }
        public long ToRegionId { get; set; }
    }
}
