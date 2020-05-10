﻿using System.Collections.Generic;

namespace REvernus.Database.EveDbModels
{
    public class InvMarketGroups
    {
        public long MarketGroupId { get; set; }
        public long? ParentGroupId { get; set; }
        public string MarketGroupName { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
        public byte[] HasTypes { get; set; }

        public virtual InvMarketGroups Parent { get; set; }
        public virtual ICollection<InvMarketGroups> Children { get; set; }
        public virtual ICollection<InvTypes> InventoryChildren { get; set; }
    }
}
