using Jot;
using Jot.Storage;
using System.Windows;

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
    }
}
