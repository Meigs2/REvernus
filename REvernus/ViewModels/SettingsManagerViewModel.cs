using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Settings;
using REvernus.Utilities;
using System;
using System.Media;
using System.Windows;

namespace REvernus.ViewModels
{
    public class SettingsManagerViewModel : BindableBase
    {
        public SettingsManagerViewModel()
        {
            Services.Tracker.Track(this);
        }

        public MarketSettings MarketSettings { get; set; } = (MarketSettings)App.Settings.MarketSettings.Clone();

        public MarketOrdersTabSettings MarketOrdersTabSettings { get; set; } =
            (MarketOrdersTabSettings)App.Settings.MarketOrdersTabSettings.Clone();

        public DelegateCommand<Window> SaveSettingsCommand => new DelegateCommand<Window>(SaveSettings);

        public DelegateCommand<Window> CloseWithoutSavingCommand => new DelegateCommand<Window>(CloseWithoutSaving);

        private void CloseWithoutSaving(Window window)
        {
            window?.Close();
        }

        private void SaveSettings(Window window)
        {
            PropertiesHelper.CopyProperties(MarketSettings, App.Settings.MarketSettings);
            PropertiesHelper.CopyProperties(MarketOrdersTabSettings, App.Settings.MarketOrdersTabSettings);
            OnSettingsSaved(EventArgs.Empty);
            SystemSounds.Exclamation.Play();
            window?.Close();
        }

        protected virtual void OnSettingsSaved(EventArgs e)
        {
            var handler = SettingsSaved;
            handler?.Invoke(this, e);
        }

        public static event EventHandler SettingsSaved;
    }
}