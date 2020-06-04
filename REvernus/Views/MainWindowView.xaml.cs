using REvernus.Core;
using System;
using System.ComponentModel;
using System.Windows;

namespace REvernus
{
    /// <summary>
    ///     Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            Services.Tracker.Track(this);

            Closing += MainWindowView_Closing;
        }

        private void MainWindowView_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}