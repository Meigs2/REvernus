namespace REvernus.Database.EveDbModels
{
    public class RamAssemblyLineTypes
    {
        public long AssemblyLineTypeId { get; set; }
        public string AssemblyLineTypeName { get; set; }
        public string Description { get; set; }
        public double? BaseTimeMultiplier { get; set; }
        public double? BaseMaterialMultiplier { get; set; }
        public double? BaseCostMultiplier { get; set; }
        public double? Volume { get; set; }
        public long? ActivityId { get; set; }
        public double? MinCostPerHour { get; set; }
    }
}
