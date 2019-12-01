using Prism.Mvvm;
using REvernus.Core;

namespace REvernus.ViewModels
{
    public class SettingsManagerViewModel : BindableBase
    {
        public int AutoUpdateTimer
        {
            get => App.Settings.MarketSettings.AutoUpdateTimer;
            set
            {
                App.Settings.MarketSettings.AutoUpdateTimer = value;
                RaisePropertyChanged();
            }
        }

        public string MarketHotkeyUp
        {
            get => App.Settings.HotkeySettings.MarketUpHotkey;
            set
            {
                App.Settings.HotkeySettings.MarketUpHotkey = value;
                RaisePropertyChanged();
            }
        }

        public string MarketHotkeyDown
        {
            get => App.Settings.HotkeySettings.MarketDownHotkey;
            set
            {
                App.Settings.HotkeySettings.MarketDownHotkey = value;
                RaisePropertyChanged();
            }
        }

        public bool AutoUpdateTimerEnabled
        {
            get => App.Settings.MarketSettings.AutoUpdateTimerEnabled;
            set
            {
                App.Settings.MarketSettings.AutoUpdateTimerEnabled = value;
                RaisePropertyChanged();
            }
        }

        public double UndercutBy
        {
            get => App.Settings.MarketSettings.UndercutBy;
            set
            {
                App.Settings.MarketSettings.UndercutBy = value;
                RaisePropertyChanged();
            }
        }

        public SettingsManagerViewModel()
        {
            Services.Tracker.Track(this);
        }

    }
}