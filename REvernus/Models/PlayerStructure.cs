namespace REvernus.Models
{
    using System;

    [Serializable]
    public class PlayerStructure
    {
        public DateTime? AddedAt { get; set; }
        public long? AddedBy { get; set; }
        public bool? Enabled { get; set; }
        public bool IsPublic { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int SolarSystemId { get; set; }
        public long StructureId { get; set; }
        public int? TypeId { get; set; }
    }
}