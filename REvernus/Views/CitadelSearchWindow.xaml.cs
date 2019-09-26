using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using EVEStandard.Models;
using REvernus.Models;
using REvernus.ViewModels;

namespace REvernus.Views
{
    /// <summary>
    /// Interaction logic for EsiSearchWindow.xaml
    /// </summary>
    public partial class CitadelSearchWindow : Window
    {
        public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (DataContext is CitadelSearchWindowViewModel a) a.SelectPressed += CloseWindow;
        }

        private void CloseWindow(object sender, CitadelSearchWindowViewModel.CitadelSearchEventArgs e)
        {
            SelectedStructures = e.SelectedStructures;

            Close();
        }

        public CitadelSearchWindow()
        {
            InitializeComponent();
        }
    }
}
