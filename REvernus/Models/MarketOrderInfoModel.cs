using System;
using System.Collections.Generic;
using System.Text;
using EVEStandard.Models;
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
        public string Location => Order.LocationId.ToString();
        public double Price => Order.Price;
        public bool IsOutbid { get; set; } = false;
        public int OutbidDelta { get; set; } = 0;
        public double Difference { get; set; } = 0.0;
        public int VolumeRemaining => Order.VolumeRemain;
        public int VolumeTotal => Order.VolumeTotal;
        public string VolumeRatio => VolumeRemaining + "/" + VolumeTotal;
        public double TotalValue { get; set; } = 0.0;
        public TimeSpan CompletionEta { get; set; }
        public TimeSpan OrderAge => Order.Issued - DateTime.Now;

        public MarketOrderInfoModel(CharacterMarketOrder order)
        {
            Order = order;
        }
    }
}
