using System;
using System.Collections.Generic;
using System.Text;
using Jot.Configuration;

namespace REvernus.Settings
{
    public class AppSettings : ITrackingAware<AppSettings>
    {
        public PersistedSettings PersistedSettings { get; set; } = new PersistedSettings();

        public void ConfigureTracking(TrackingConfiguration<AppSettings> configuration)
        {
            configuration.Properties(s => new {s.PersistedSettings});
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
