﻿namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapDenormalize
    {
        public long? CelestialIndex { get; set; }
        public long? ConstellationId { get; set; }
        public long? GroupId { get; set; }
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long? OrbitId { get; set; }
        public long? OrbitIndex { get; set; }
        public double? Radius { get; set; }
        public long? RegionId { get; set; }
        public double? Security { get; set; }
        public long? SolarSystemId { get; set; }
        public long? TypeId { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
    }
}