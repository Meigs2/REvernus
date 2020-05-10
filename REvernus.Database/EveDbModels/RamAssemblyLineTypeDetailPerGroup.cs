namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamAssemblyLineTypeDetailPerGroup
    {
        public long AssemblyLineTypeId { get; set; }
        public double? CostMultiplier { get; set; }
        public long GroupId { get; set; }
        public double? MaterialMultiplier { get; set; }
        public double? TimeMultiplier { get; set; }
    }
}