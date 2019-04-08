using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Navigation;
using Prism.Commands;
using REvernus.Core;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DelegateCommand ButtonClickCommand { get; }

        public MainWindowViewModel()
        {
            Utilities.Startup.PerformStartupActions();
            Log.Info("New session of REvernus has been started.");

            ButtonClickCommand = new DelegateCommand(ShutDown);
        }

        public string Message { get; set; } = "Hello .NET 3.0!";

        public void ShutDown()
        {
            Application.Current.Shutdown();
        }
    }
}
