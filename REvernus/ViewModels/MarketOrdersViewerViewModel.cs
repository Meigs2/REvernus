using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using REvernus.Utilities;

namespace REvernus.ViewModels
{
    public class MarketOrdersViewerViewModel : BindableBase
    {
        private DataTable _marketOrders;
        public DataTable MarketOrders
        {
            get => _marketOrders ??= new DataTable();
            set => SetProperty(ref _marketOrders, value);
        }

        public MarketOrdersViewerViewModel()
        {
            GetOrdersCommand = new DelegateCommand(async () => await GetMarketData());
        }

        private async Task GetMarketData()
        {
            MarketOrders = await SdeData.GetInventoryTypesAsync();
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
