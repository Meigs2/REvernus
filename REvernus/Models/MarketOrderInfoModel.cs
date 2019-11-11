using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<MarketOrder> MarketOrders { get; set; }
        public List<MarketOrder> BuyOrders => MarketOrders.Where(o => o.IsBuyOrder).OrderByDescending(o => o.Price).ToList();
        public List<MarketOrder> SellOrders => MarketOrders.Where(o => !o.IsBuyOrder).OrderBy(o => o.Price).ToList();
        public string Owner { get; set; }
        public bool IsBuyOrder => Order.IsBuyOrder == true;
        public string ItemName  => EveItems.TypeIdToTypeName(Order.TypeId);
        public int ItemId => Order.TypeId;
        public string LocationName { get; set; }
        public double Price => Order.Price;
        public bool IsOutbid
        {
            get
            {
                var isOutbid = IsOrderOutbid(MarketOrders, Order, out var diff);
                Difference = diff;
                return isOutbid;
            }
        }
        public int OutbidDelta
        {
            get
            {
                if (IsBuyOrder)
                {
                    return BuyOrders.FindIndex(o => o.OrderId == Order.OrderId);
                }
                else
                {
                    return SellOrders.FindIndex(o => o.OrderId == Order.OrderId);
                }
            }
        }
        public double Difference { get; set; }
        public int VolumeRemaining => Order.VolumeRemain;
        public int VolumeTotal => Order.VolumeTotal;
        public string VolumeRatio => VolumeRemaining + "/" + VolumeTotal;
        public double TotalValue => Order.VolumeRemain * Order.Price;
        public double TypeMargin
        {
            get
            {
                if (SellOrders[0] != null && BuyOrders[0] != null)
                {
                    return (SellOrders[0].Price - BuyOrders[0].Price) / SellOrders[0].Price;
                }
                else
                {
                    return double.PositiveInfinity;
                }
            }
        }

        public double CurrentMargin
        {
            get
            {
                if (IsBuyOrder && SellOrders[0] != null)
                {
                    return (SellOrders[0].Price - Order.Price) / SellOrders[0].Price;
                }
                if (!IsBuyOrder && BuyOrders[0] != null)
                {
                    return (Order.Price - BuyOrders[0].Price) / Order.Price;
                }

                return 0.0;
            }
        }

        public string CompletionEta
        {
            get
            {
                if (VolumeRemaining == VolumeTotal)
                {
                    return "Infinity";
                }
                return ((OrderAge / (VolumeTotal - VolumeRemaining) * VolumeRemaining)).ToString(@"dd\:hh\:mm");
            }
        }

        public TimeSpan OrderAge => DateTime.UtcNow - Order.Issued;
        public TimeSpan TimeLeft => TimeSpan.FromDays(Order.Duration) - OrderAge;

        public MarketOrderInfoModel(CharacterMarketOrder order, REvernusCharacter owner, string locationName, List<MarketOrder> marketOrders)
        {
            Order = order;
            Owner = owner.CharacterName;
            LocationName = locationName;
            MarketOrders = marketOrders;
        }

        private bool IsOrderOutbid(List<MarketOrder> marketOrders, CharacterMarketOrder order, out double difference)
        {
            difference = 0;

            if (order.IsBuyOrder == null || order.IsBuyOrder == false)
            {
                var buyOrders = marketOrders.Where(o => !o.IsBuyOrder).ToList();

                var min = buyOrders.OrderBy(o => o.Price).FirstOrDefault();
                if (min != null && order.OrderId != min.OrderId && min.Price <= order.Price)
                {
                    difference = min.Price - order.Price;
                    return true;
                }
            }
            else
            {
                var sellOrders = marketOrders.Where(o => o.IsBuyOrder).ToList();

                var max = sellOrders.OrderByDescending(o => o.Price).FirstOrDefault();
                if (max != null && order.OrderId != max.OrderId && max.Price >= order.Price)
                {
                    difference = max.Price - order.Price;
                    return true;
                }
            }

            return false;
        }
    }
}
