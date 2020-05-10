namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapConstellations
    {
        public long ConstellationId { get; set; }
        public string ConstellationName { get; set; }
        public long? FactionId { get; set; }
        public double? Radius { get; set; }
        public long? RegionId { get; set; }
        public double? X { get; set; }
        public double? XMax { get; set; }
        public double? XMin { get; set; }
        public double? Y { get; set; }
        public double? YMax { get; set; }
        public double? YMin { get; set; }
        public double? Z { get; set; }
        public double? ZMax { get; set; }
        public double? ZMin { get; set; }
    }
}