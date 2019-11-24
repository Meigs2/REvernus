using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class StaStationTypes
    {
        public long StationTypeId { get; set; }
        public double? DockEntryX { get; set; }
        public double? DockEntryY { get; set; }
        public double? DockEntryZ { get; set; }
        public double? DockOrientationX { get; set; }
        public double? DockOrientationY { get; set; }
        public double? DockOrientationZ { get; set; }
        public long? OperationId { get; set; }
        public long? OfficeSlots { get; set; }
        public double? ReprocessingEfficiency { get; set; }
        public byte[] Conquerable { get; set; }
    }
}
