using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class IndustryActivityProbabilities
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? ProductTypeId { get; set; }
        public byte[] Probability { get; set; }
    }
}
