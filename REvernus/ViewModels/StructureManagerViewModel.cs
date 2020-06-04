using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Views;
using System.Collections;

namespace REvernus.ViewModels
{
    public class StructureManagerViewModel : BindableBase
    {
        public StructureManagerViewModel()
        {
            RemoveStructuresCommand = new DelegateCommand<IList>(RemoveStructures);
        }

        public DelegateCommand AddStructuresCommand { get; set; } = new DelegateCommand(AddNewStructures);
        public DelegateCommand<IList> RemoveStructuresCommand { get; set; }

        private void RemoveStructures(IList structures)
        {
            StructureManager.RemoveStructuresFromDatabase(structures);
        }

        private static void AddNewStructures()
        {
            var structureSearchView = new StructureSearchView();
            structureSearchView.ShowDialog();

            StructureManager.InsertStructuresIntoDatabase(structureSearchView.SelectedStructures);
        }
    }
}