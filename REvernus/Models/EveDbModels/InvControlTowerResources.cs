using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class InvControlTowerResources
    {
        public long ControlTowerTypeId { get; set; }
        public long ResourceTypeId { get; set; }
        public long? Purpose { get; set; }
        public long? Quantity { get; set; }
        public double? MinSecurityLevel { get; set; }
        public long? FactionId { get; set; }
    }
}
