namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamAssemblyLineTypes
    {
        public long? ActivityId { get; set; }
        public long AssemblyLineTypeId { get; set; }
        public string AssemblyLineTypeName { get; set; }
        public double? BaseCostMultiplier { get; set; }
        public double? BaseMaterialMultiplier { get; set; }
        public double? BaseTimeMultiplier { get; set; }
        public string Description { get; set; }
        public double? MinCostPerHour { get; set; }
        public double? Volume { get; set; }
    }
}