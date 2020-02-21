using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace REvernus.Settings
{
    public class MarketSettings : BindableBase, ICloneable
    {
        public double PriceDelta { get; set; } = 0.01;
        public double MaxRandom { get; set; } = 0.00;
        public double GetUndercut => (new Random().NextDouble() * MaxRandom) + PriceDelta;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
