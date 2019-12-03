using Jot;
using Jot.Storage;
using REvernus.Utilities;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace REvernus.Views
{
    /// <summary>
    /// Interaction logic for SettingsManagerView.xaml
    /// </summary>
    public partial class SettingsManagerView : Window
    {
        private Tracker Tracker { get; } = new Tracker(new JsonFileStore(Utilities.Paths.SerializedDataFolder));
        public SettingsManagerView()
        {
            InitializeComponent();
            Tracker
                .Configure<SettingsManagerView>()
                .Id(w => w.Name, GetType().Name)
                .Properties(w => new { w.Top, w.Width, w.Height, w.Left, w.WindowState })
                .PersistOn(nameof(Closing))
                .StopTrackingOn(nameof(Closing));

            Tracker.Track(this);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void HotkeyTextbox(object sender, KeyEventArgs args)
        {
            ((TextBox)sender).Text = KeysHelper.ToWinforms(Keyboard.Modifiers).ToString() + "+" + args.Key;

        }
    }
}
