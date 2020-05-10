namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapLandmarks
    {
        public string Description { get; set; }
        public long? IconId { get; set; }
        public long LandmarkId { get; set; }
        public string LandmarkName { get; set; }
        public long? LocationId { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
    }
}