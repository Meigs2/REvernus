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
    public class StructureManagerViewModel : BindableBase
    {
        public StructureManagerViewModel()
        {
            RemoveStructuresCommand = new DelegateCommand<IList>(RemoveStructures);
        }

        private void RemoveStructures(IList structures)
        {
            StructureManager.RemoveStructuresFromDatabase(structures);
        }

        public DelegateCommand AddStructuresCommand { get; set; } = new DelegateCommand(AddNewStructures);
        public DelegateCommand<IList> RemoveStructuresCommand { get; set; }
        private static void AddNewStructures()
        {
            var structureSearchView = new StructureSearchView();
            structureSearchView.ShowDialog();

            StructureManager.InsertStructuresIntoDatabase(structureSearchView.SelectedStructures);
        }
    }
}
