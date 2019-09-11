using System.Windows;
using REvernus.Models;

namespace REvernus.Views
{
    /// <summary>
    /// Interaction logic for EsiSearchWindow.xaml
    /// </summary>
    public partial class CitadelSearchWindow : Window
    {
        public CitadelListItem CitadelList { get; set; }

        public CitadelSearchWindow()
        {
            InitializeComponent();
        }
    }
}
