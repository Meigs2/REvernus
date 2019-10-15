using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Jot;
using Jot.Storage;
using REvernus.Core;

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
