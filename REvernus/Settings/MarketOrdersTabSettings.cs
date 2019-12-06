using System;

namespace REvernus.Settings
{
    [Serializable]
    public class MarketOrdersTabSettings
    {
        public int AutoUpdateTimer { get; set; } = 1200;
        public bool AutoUpdateTimerEnabled { get; set; } = true;
        public bool ShowInEveClient { get; set; } = true;
        public string MarketUpHotkey { get; set; } = "Control+X";

        public string MarketDownHotkey { get; set; } = "Control+Z";
    }
}