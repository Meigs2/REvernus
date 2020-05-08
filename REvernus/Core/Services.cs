using System.Windows.Forms;
using Jot;
using Jot.Storage;

namespace REvernus.Core
{
    using REvernus.Utilites;

    public  static class Services
    {
        public static Tracker Tracker = new Tracker(new JsonFileStore(Paths.SerializedDataFolder));

        /// <summary>
        /// This class initializes the tracker for tracking the status of objects, ex the position of a window
        /// in-between sessions. 
        /// </summary>
        static Services()
        {
            // Tell the tracker how we want to track Window classes
            Tracker
                .Configure<MainWindowView>()
                .Id(w => w.Name, SystemInformation.VirtualScreen.Size)
                .Properties(w => new { w.Top, w.Width, w.Height, w.Left, w.WindowState })
                .PersistOn(nameof(MainWindowView.Closing))
                .StopTrackingOn(nameof(MainWindowView.Closing));
        }
    }
}
