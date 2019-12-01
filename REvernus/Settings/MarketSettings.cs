using System;

namespace REvernus.Settings
{
    [Serializable]
    public class MarketSettings
    {
        public int AutoUpdateTimer { get; set; } = 1200;

        public double UndercutBy { get; set; } = 0.1;
        public bool AutoUpdateTimerEnabled { get; set; } = true;
    }
}