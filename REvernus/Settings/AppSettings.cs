using System;
using System.Collections.Generic;
using System.Text;
using Jot.Configuration;

namespace REvernus.Settings
{
    public class AppSettings : ITrackingAware<AppSettings>
    {
        public PersistedSettings PersistedSettings { get; set; } = new PersistedSettings();
        public MarginToolSettings MarginToolSettings { get; set; } = new MarginToolSettings();

        public HotkeySettings HotkeySettings { get; set; } = new HotkeySettings();

        public MarketSettings MarketSettings { get; set; } = new MarketSettings();

        public void ConfigureTracking(TrackingConfiguration<AppSettings> configuration)
        {
            configuration.Properties(s => new
            {
                s.PersistedSettings,
                s.MarginToolSettings,
                s.MarketSettings,
                s.HotkeySettings
            });
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
