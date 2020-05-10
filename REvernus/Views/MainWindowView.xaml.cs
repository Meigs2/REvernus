namespace REvernus.Views
{
    using System;
    using System.ComponentModel;

    using REvernus.Core;

    /// <summary>
    ///     Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
            CharacterComboBox.DataContext = App.CharacterManager;

            Services.Tracker.Track(this);

            Closing += MainWindowView_Closing;
        }

        private void MainWindowView_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}