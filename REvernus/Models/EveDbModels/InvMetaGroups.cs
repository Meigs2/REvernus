using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class InvMetaGroups
    {
        public long MetaGroupId { get; set; }
        public string MetaGroupName { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
    }
}
