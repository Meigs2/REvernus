using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class EveUnits
    {
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
