namespace REvernus.Views
{
    using System;
    using System.Collections.Generic;

    using REvernus.Models;
    using REvernus.ViewModels;

    public partial class StructureSearchView
    {
        public StructureSearchView()
        {
            InitializeComponent();
        }

        public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (DataContext is StructureSearchViewModel a)
                a.SelectPressed += CloseWindow;
        }

        private void CloseWindow(object sender, StructureSearchViewModel.StructureSearchEventArgs e)
        {
            SelectedStructures = e.SelectedStructures;

            Close();
        }
    }
}