using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class InvContrabandTypes
    {
        public long FactionId { get; set; }
        public long TypeId { get; set; }
        public double? StandingLoss { get; set; }
        public double? ConfiscateMinSec { get; set; }
        public double? FineByValue { get; set; }
        public double? AttackMinSec { get; set; }
    }
}
