using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Utilities.StaticData;

namespace REvernus.Models
{
    public class MarketOrderInfoModel
    {

        public CharacterMarketOrder Order { get; set; }
        public List<MarketOrder> MarketOrders { get; set; } = new List<MarketOrder>();
        public string Owner { get; set; }
        public bool IsBuyOrder => Order.IsBuyOrder == true;
        public string ItemName  => EveItems.TypeIdToTypeName(Order.TypeId);
        public int ItemId => Order.TypeId;
        public string Location { get; set; }

        public double Price => Order.Price;
        public bool IsOutbid { get; set; } = false;
        public int OutbidDelta { get; set; } = 0;
        public double Difference { get; set; } = 0.0;
        public int VolumeRemaining => Order.VolumeRemain;
        public int VolumeTotal => Order.VolumeTotal;
        public string VolumeRatio => VolumeRemaining + "/" + VolumeTotal;
        public double TotalValue { get; set; } = 0.0;
        public TimeSpan CompletionEta { get; set; } = TimeSpan.Zero;
        public TimeSpan OrderAge => DateTime.UtcNow - Order.Issued;

        public MarketOrderInfoModel(CharacterMarketOrder order, REvernusCharacter owner, string location)
        {
            Order = order;
            Owner = owner.CharacterName;
            Location = location;
        }
    }
}
