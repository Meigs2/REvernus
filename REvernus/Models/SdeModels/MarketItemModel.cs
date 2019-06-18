using System.Collections.Generic;
using System.Windows.Documents;

namespace REvernus.Models.SdeModels
{
    public class MarketItemModel
    {
        private List<MarketItemModel> Children { get; } = new List<MarketItemModel>();
        private bool? IsChecked { get; set; }
        private bool IsInitiallySelected { get; }
        private string Name { get; }
    }
}