using System;

namespace REvernus.Models
{
    [Serializable]
    public class PlayerStructure
    {
        public long StructureId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int SolarSystemId { get; set; }
        public int? TypeId { get; set; }
        public long? AddedBy { get; set; }
        public DateTime? AddedAt { get; set; }
        public bool? Enabled { get; set; }
        public bool isPublic { get; set; }
    }
}
