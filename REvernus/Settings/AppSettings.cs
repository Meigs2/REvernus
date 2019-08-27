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

        public void ConfigureTracking(TrackingConfiguration<AppSettings> configuration)
        {
            configuration.Properties(s => new
            {
                s.PersistedSettings,
                s.MarginToolSettings
            });
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
