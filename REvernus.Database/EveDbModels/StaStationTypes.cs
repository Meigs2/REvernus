namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class StaStationTypes
    {
        public byte[] Conquerable { get; set; }
        public double? DockEntryX { get; set; }
        public double? DockEntryY { get; set; }
        public double? DockEntryZ { get; set; }
        public double? DockOrientationX { get; set; }
        public double? DockOrientationY { get; set; }
        public double? DockOrientationZ { get; set; }
        public long? OfficeSlots { get; set; }
        public long? OperationId { get; set; }
        public double? ReprocessingEfficiency { get; set; }
        public long StationTypeId { get; set; }
    }
}