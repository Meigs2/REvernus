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
    public partial class CitadelSearchView : Window
    {
        public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (DataContext is CitadelSearchViewModel a) a.SelectPressed += CloseWindow;
        }

        private void CloseWindow(object sender, CitadelSearchViewModel.CitadelSearchEventArgs e)
        {
            SelectedStructures = e.SelectedStructures;

            Close();
        }

        public CitadelSearchView()
        {
            InitializeComponent();
        }
    }
}
