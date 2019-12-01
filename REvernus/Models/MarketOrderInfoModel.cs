using EVEStandard.Models;
using Prism.Mvvm;
using REvernus.Utilities.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REvernus.Models
{
    public class MarketOrderInfoModel : BindableBase
    {
        private CharacterMarketOrder _order;
        private List<MarketOrder> _marketOrders;
        private List<MarketOrder> _buyOrders = new List<MarketOrder>();
        private List<MarketOrder> _sellOrders = new List<MarketOrder>();
        private string _owner;
        private bool _isBuyOrder;
        private string _itemName;
        private int _itemId;
        private string _locationName;
        private double _price;
        private bool _isOutbid;
        private int _outbidDelta;
        private double _difference;
        private int _volumeRemaining;
        private int _volumeTotal;
        private string _volumeRatio;
        private double _orderValue;
        private double _typeMargin;
        private double _orderMargin;
        private string _completionEta;
        private TimeSpan _orderAge = TimeSpan.Zero;
        private TimeSpan _timeLeft = TimeSpan.Zero;
        private double? _escrow;

        public CharacterMarketOrder Order
        {
            get => _order;
            set
            {
                SetProperty(ref _order, value);
                IsBuyOrder = Order.IsBuyOrder == true;
                ItemName = EveItems.TypeIdToTypeName(Order.TypeId);
                ItemId = Order.TypeId;
                Price = Order.Price;
                VolumeRemaining = Order.VolumeRemain;
                VolumeTotal = Order.VolumeTotal;
                VolumeRatio = VolumeRemaining + "/" + VolumeTotal;
                OrderValue = Order.Price * Order.VolumeRemain;
                OrderAge = DateTime.UtcNow - Order.Issued;
                TimeLeft = TimeSpan.FromDays(Order.Duration) - OrderAge;
                Escrow = Order.Escrow;

                CompletionEta = VolumeRemaining == VolumeTotal ? "Infinity" : ((OrderAge / (VolumeTotal - VolumeRemaining) * VolumeRemaining)).ToString(@"dd\:hh\:mm");
            }
        }

        public List<MarketOrder> MarketOrders
        {
            get => _marketOrders;
            set
            {
                SetProperty(ref _marketOrders, value);
                BuyOrders = MarketOrders.Where(o => o.IsBuyOrder).OrderByDescending(o => o.Price).ToList();
                SellOrders = MarketOrders.Where(o => !o.IsBuyOrder).OrderBy(o => o.Price).ToList();
                IsOutbid = IsOrderOutbid(MarketOrders, Order, out var diff);
                Difference = diff;

                // Outbid delta
                OutbidDelta = IsBuyOrder ? BuyOrders.FindIndex(o => o.OrderId == Order.OrderId) : SellOrders.FindIndex(o => o.OrderId == Order.OrderId);
                if (SellOrders.Count > 0 && BuyOrders.Count > 0)
                {
                    TypeMargin = (SellOrders[0].Price - BuyOrders[0].Price) / SellOrders[0].Price;
                }
                else
                {
                    TypeMargin = double.PositiveInfinity;
                }

                // OrderMargin
                if (IsBuyOrder && SellOrders.Count > 0)
                {
                    OrderMargin = (SellOrders[0].Price - Order.Price) / SellOrders[0].Price;
                }
                else if (!IsBuyOrder && BuyOrders.Count > 0)
                {
                    OrderMargin = (Order.Price - BuyOrders[0].Price) / Order.Price;
                }
                else
                {
                    OrderMargin = 0.0;
                }
            }
        }

        public string Owner
        {
            get => _owner;
            set => SetProperty(ref _owner, value);
        }

        public string LocationName
        {
            get => _locationName;
            set => SetProperty(ref _locationName, value);
        }

        public List<MarketOrder> BuyOrders
        {
            get => _buyOrders;
            set => SetProperty(ref _buyOrders, value);
        }

        public List<MarketOrder> SellOrders
        {
            get => _sellOrders;
            set => SetProperty(ref _sellOrders, value);
        }

        public bool IsBuyOrder
        {
            get => _isBuyOrder;
            set => SetProperty(ref _isBuyOrder, value);
        }

        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        public int ItemId
        {
            get => _itemId;
            set => SetProperty(ref _itemId, value);
        }

        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public bool IsOutbid
        {
            get => _isOutbid;
            set => SetProperty(ref _isOutbid, value);
        }

        public int OutbidDelta
        {
            get => _outbidDelta;
            set => SetProperty(ref _outbidDelta, value);
        }

        public double Difference
        {
            get => _difference;
            set => SetProperty(ref _difference, value);
        }

        public int VolumeRemaining
        {
            get => _volumeRemaining;
            set => SetProperty(ref _volumeRemaining, value);
        }

        public int VolumeTotal
        {
            get => _volumeTotal;
            set => SetProperty(ref _volumeTotal, value);
        }

        public string VolumeRatio
        {
            get => _volumeRatio;
            set => SetProperty(ref _volumeRatio, value);
        }

        public double OrderValue
        {
            get => _orderValue;
            set => SetProperty(ref _orderValue, value);
        }

        public double TypeMargin
        {
            get => _typeMargin;
            set => SetProperty(ref _typeMargin, value);
        }

        public double OrderMargin
        {
            get => _orderMargin;
            set => SetProperty(ref _orderMargin, value);
        }

        public string CompletionEta
        {
            get => _completionEta;
            set => SetProperty(ref _completionEta, value);
        }

        public TimeSpan OrderAge
        {
            get => _orderAge;
            set => SetProperty(ref _orderAge, value);
        }

        public TimeSpan TimeLeft
        {
            get => _timeLeft;
            set => SetProperty(ref _timeLeft, value);
        }

        public double? Escrow
        {
            get => _escrow;
            set => SetProperty(ref _escrow, value);
        }

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
