using System;
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
            
        }

        public DelegateCommand AddCitadelsCommand { get; set; } = new DelegateCommand(AddNewCitadels);
        private static void AddNewCitadels()
        {
            var citadelSearchWindow = new CitadelSearchWindow();
            citadelSearchWindow.ShowDialog();

            CitadelManager.InsertStructuresIntoDatabase(citadelSearchWindow.SelectedStructures);
            CitadelManager.LoadCitadelsFromDatabase();
        }
    }
}
