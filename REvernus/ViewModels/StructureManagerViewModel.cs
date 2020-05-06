using System.Collections;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Core;
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
