using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Models;
using REvernus.Utilities;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class CitadelManagerViewModel : BindableBase
    {
        public CitadelManagerViewModel()
        {
            RemoveCitadelsCommand = new DelegateCommand<IList>(RemoveStructures);
        }

        private void RemoveStructures(IList structures)
        {
            CitadelManager.RemoveStructuresFromDatabase(structures);
        }

        public DelegateCommand AddCitadelsCommand { get; set; } = new DelegateCommand(AddNewCitadels);
        public DelegateCommand<IList> RemoveCitadelsCommand { get; set; }
        private static void AddNewCitadels()
        {
            var citadelSearchWindow = new CitadelSearchWindow();
            citadelSearchWindow.ShowDialog();

            CitadelManager.InsertStructuresIntoDatabase(citadelSearchWindow.SelectedStructures);
        }
    }
}
