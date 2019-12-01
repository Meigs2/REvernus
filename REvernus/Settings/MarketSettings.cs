using System;

namespace REvernus.Settings
{
    [Serializable]
    public class MarketSettings
    {
        public int AutoUpdateTimer { get; set; } = 1200;
    }
}