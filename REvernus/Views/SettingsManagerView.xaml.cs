using Jot;
using Jot.Storage;
using REvernus.Utilities;
using System;
using System.Text;
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
            // The text box grabs all input.
            args.Handled = true;

            // Fetch the actual shortcut key.
            var key = (args.Key == Key.System ? args.SystemKey : args.Key);

            // Ignore modifier keys.
            if (key == Key.LeftShift || key == Key.RightShift
                                     || key == Key.LeftCtrl || key == Key.RightCtrl
                                     || key == Key.LeftAlt || key == Key.RightAlt
                                     || key == Key.LWin || key == Key.RWin)
            {
                return;
            }

            var mods = KeysHelper.ToWinforms(Keyboard.Modifiers);

            // Build the shortcut key name.
            StringBuilder shortcutText = new StringBuilder();
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                shortcutText.Append("Control+");
            }
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                shortcutText.Append("Shift+");
            }
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                shortcutText.Append("Alt+");
            }
            shortcutText.Append(key.ToString());

            // Update the text box.
            ((TextBox)sender).Text = shortcutText.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DockPanel.Focus();
        }
    }
}
