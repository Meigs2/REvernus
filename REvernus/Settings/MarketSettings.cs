using System;
using System.Collections.Generic;
using System.Text;

namespace REvernus.Settings
{
    public class MarketSettings
    {
        public double PriceDelta { get; set; } = 0.01;
        public double MaxRandom { get; set; } = 0.00;
        public double GetUndercut => (new Random().NextDouble() * MaxRandom) + PriceDelta;
    }
}
