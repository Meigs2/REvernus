using Jot;
using Jot.Storage;
using System.Windows;

namespace REvernus.Views
{
    public partial class StructureManagerView : Window
    {
        private Tracker Tracker { get; } = new Tracker(new JsonFileStore(Utilities.Paths.SerializedDataFolder));

        public StructureManagerView()
        {
            InitializeComponent();

            Tracker
                .Configure<StructureManagerView>()
                .Id(w => w.Name, GetType().Name)
                .Properties(w => new { w.Top, w.Width, w.Height, w.Left, w.WindowState })
                .PersistOn(nameof(Closing))
                .StopTrackingOn(nameof(Closing));

            Tracker.Track(this);
        }
    }
}
