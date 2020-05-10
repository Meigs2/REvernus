using System;
using Jot.Configuration;

namespace REvernus.Settings
{
    public class AppSettings : ITrackingAware<AppSettings>
    {
        public CharacterManagerSettings CharacterManagerSettings { get; } = new CharacterManagerSettings();
        public MarginToolSettings MarginToolSettings { get; } = new MarginToolSettings();
        public MarketOrdersTabSettings MarketOrdersTabSettings { get; } = new MarketOrdersTabSettings();
        public MarketSettings MarketSettings { get; } = new MarketSettings();

        public void ConfigureTracking(TrackingConfiguration<AppSettings> configuration)
        {
            configuration.Properties(s => new
            {
                s.CharacterManagerSettings,
                s.MarginToolSettings,
                s.MarketOrdersTabSettings,
                s.MarketSettings
            });
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
