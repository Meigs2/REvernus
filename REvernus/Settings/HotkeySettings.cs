using System;

namespace REvernus.Settings
{
    [Serializable]
    public class HotkeySettings
    {
        public string MarketUpHotkey { get; set; } = "Control+X";

        public string MarketDownHotkey { get; set; } = "Control+Z";
    }
}