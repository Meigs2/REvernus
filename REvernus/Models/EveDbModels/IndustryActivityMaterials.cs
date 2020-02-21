using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class IndustryActivityMaterials
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? MaterialTypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
