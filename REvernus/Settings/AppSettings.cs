namespace REvernus.Settings
{
    using System;

    using JetBrains.Annotations;

    using Jot.Configuration;

    public class AppSettings : ITrackingAware<AppSettings>
    {
        [UsedImplicitly]
        public CharacterManagerSettings CharacterManagerSettings { get; set; } = new CharacterManagerSettings();
        
        [UsedImplicitly]
        public MarginToolSettings MarginToolSettings { get; set; } = new MarginToolSettings();

        [UsedImplicitly]
        public MarketOrdersTabSettings MarketOrdersTabSettings { get; set; } = new MarketOrdersTabSettings();

        [UsedImplicitly]
        public MarketSettings MarketSettings { get; set; } = new MarketSettings();

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