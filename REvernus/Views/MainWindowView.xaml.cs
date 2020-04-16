using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using REvernus.Core;
using REvernus.ViewModels;

namespace REvernus
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            CharacterComboBox.DataContext = App.CharacterManager;

            Services.Tracker.Track(this);

            this.Closing += MainWindowView_Closing;
        }

        private void MainWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
