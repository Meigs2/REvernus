using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class CitadelManagerViewModel
    {
        public CitadelManagerViewModel()
        {

        }

        public DelegateCommand AddCitadelsCommand { get; set; } = new DelegateCommand(AddNewCitadels);
        private static void AddNewCitadels()
        {
            var a = new CitadelSearchWindow();
            a.ShowDialog();
        }
    }
}
