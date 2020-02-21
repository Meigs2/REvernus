using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class CertCerts
    {
        public long CertId { get; set; }
        public string Description { get; set; }
        public long? GroupId { get; set; }
        public string Name { get; set; }
    }
}
