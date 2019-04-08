using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Navigation;
using REvernus.Core;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand ButtonClickCommand { get; }

        public MainWindowViewModel()
        {
            ButtonClickCommand = new DelegateCommand(ShutDown);
        }

        public string Message { get; set; } = "Hello .NET 3.0!";

        public void ShutDown()
        {
            Application.Current.Shutdown();
        }
    }
}
