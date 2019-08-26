using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Jot;
using Jot.Configuration;
using Jot.Storage;

namespace REvernus.Core
{
    public  static class Services
    {
        public static Tracker Tracker = new Tracker(new JsonFileStore(Utilities.Paths.SerializedDataFolder));

        /// <summary>
        /// This class initializes the tracker for tracking the status of objects, ex the position of a window
        /// in-between sessions. 
        /// </summary>
        static Services()
        {
            // Tell the tracker how we want to track Window classes
            Tracker
                .Configure<Window>()
                .Id(w => w.Name, SystemInformation.VirtualScreen.Size)
                .Properties(w => new { w.Top, w.Width, w.Height, w.Left, w.WindowState })
                .PersistOn(nameof(Window.Closing))
                .StopTrackingOn(nameof(Window.Closing));

        }
    }
}
