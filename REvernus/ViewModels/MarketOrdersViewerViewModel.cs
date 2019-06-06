using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        MarketOrdersViewerViewModel()
        {
            GetOrdersCommand = new DelegateCommand(GetMarketData);
        }


        private void GetMarketData()
        {
            var a = SdeData.GetInventoryTypes();
            MarketOrders = a;
        }

        public DelegateCommand GetOrdersCommand { get; set; }
    }
}
