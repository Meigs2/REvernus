using REvernus.Core;
using System;
using System.Windows;

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
            CharacterComboBox.DataContext = CharacterManager.CurrentInstance;

            Services.Tracker.Track(this);

            this.Closing += MainWindowView_Closing;
        }

        private void MainWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
