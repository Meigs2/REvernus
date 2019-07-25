using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using REvernus.Utilities;
using REvernus.ViewModels;

namespace REvernus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public new static MainWindowView MainWindow { get; private set; }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Environment.ExitCode = -1;

                await StartupAndExit.PerformStartupActions();

                MainWindow = new MainWindowView();
                MainWindow.ShowDialog();
                Environment.ExitCode = -10;
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
        }
    }
}
