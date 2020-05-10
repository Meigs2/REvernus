namespace REvernus.Settings
{
    using System;

    using Prism.Mvvm;

    public class MarketSettings : BindableBase, ICloneable
    {
        public double GetUndercut => new Random().NextDouble() * MaxRandom + PriceDelta;

        // ReSharper disable once RedundantDefaultMemberInitializer
        public double MaxRandom { get; set; } = 0.00;
        public double PriceDelta { get; set; } = 0.01;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}