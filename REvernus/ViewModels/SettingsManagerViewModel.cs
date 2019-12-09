using Prism.Mvvm;
using REvernus.Core;

namespace REvernus.ViewModels
{
    public class SettingsManagerViewModel : BindableBase
    {
        public int AutoUpdateTimer
        {
            get => App.Settings.MarketOrdersTabSettings.AutoUpdateTimer;
            set
            {
                App.Settings.MarketOrdersTabSettings.AutoUpdateTimer = value;
                RaisePropertyChanged();
            }
        }

        public string MarketHotkeyUp
        {
            get => App.Settings.MarketOrdersTabSettings.MarketUpHotkey;
            set
            {
                App.Settings.MarketOrdersTabSettings.MarketUpHotkey = value;
                RaisePropertyChanged();
            }
        }

        public string MarketHotkeyDown
        {
            get => App.Settings.MarketOrdersTabSettings.MarketDownHotkey;
            set
            {
                App.Settings.MarketOrdersTabSettings.MarketDownHotkey = value;
                RaisePropertyChanged();
            }
        }

        public bool AutoUpdateTimerEnabled
        {
            get => App.Settings.MarketOrdersTabSettings.AutoUpdateTimerEnabled;
            set
            {
                App.Settings.MarketOrdersTabSettings.AutoUpdateTimerEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool ToastNoteIsEnabled
        {
            get => App.Settings.NotificationSettings.ToastNoteIsEnabled;
            set
            {
                App.Settings.NotificationSettings.ToastNoteIsEnabled = value;
                RaisePropertyChanged();
            }
        }

        public double UndercutBy
        {
            get => App.Settings.MarketSettings.PriceDelta;
            set
            {
                App.Settings.MarketSettings.PriceDelta = value;
                RaisePropertyChanged();
            }
        }

        public SettingsManagerViewModel()
        {
            Services.Tracker.Track(this);
        }

    }
}