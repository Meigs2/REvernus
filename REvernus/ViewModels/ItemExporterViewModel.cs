using Prism.Commands;
using Prism.Mvvm;
using REvernus.Database.EveDbModels;
using REvernus.Views.SimpleViews;
using System.Collections.ObjectModel;

namespace REvernus.ViewModels
{
    public class ItemExporterViewModel : BindableBase
    {
        public ObservableCollection<InvTypes> TypesCollection { get; set; } = new ObservableCollection<InvTypes>();

        public DelegateCommand SelectItemsCommand => new DelegateCommand(OpenItemExplorer);

        private void OpenItemExplorer()
        {
            var explorer = new ItemExplorerView();
            explorer.ShowDialog();

            if (explorer.WasCanceled) return;

            TypesCollection.Clear();
            TypesCollection.AddRange(explorer.SelectedTypes);
        }
    }
}