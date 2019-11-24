using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class SkinMaterials
    {
        public long SkinMaterialId { get; set; }
        public long? DisplayNameId { get; set; }
        public long? MaterialSetId { get; set; }
    }
}
