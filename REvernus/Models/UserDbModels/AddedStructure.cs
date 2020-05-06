using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REvernus.Models.UserDbModels
{
    public class AddedStructure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StructureId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int SolarSystemId { get; set; }
        public int TypeId { get; set; }
        public long AddedBy { get; set; }
        public DateTime AddedAt { get; set; }
        public bool Enabled { get; set; }
        public bool IsPublic { get; set; }
    }
}
