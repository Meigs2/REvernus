using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class DgmTypeAttributes
    {
        public long TypeId { get; set; }
        public long AttributeId { get; set; }
        public long? ValueInt { get; set; }
        public double? ValueFloat { get; set; }
    }
}
