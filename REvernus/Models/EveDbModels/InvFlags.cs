using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class InvFlags
    {
        public long FlagId { get; set; }
        public string FlagName { get; set; }
        public string FlagText { get; set; }
        public long? OrderId { get; set; }
    }
}
