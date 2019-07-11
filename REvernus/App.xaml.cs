using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            await PerformStartupActions();

            // Start the Main Window.
            MainWindow = new MainWindowView();
            MainWindow.ShowDialog();
            Current.Shutdown(-1);
        }

        private static async Task PerformStartupActions()
        {
            try
            {
                await Utilities.StartupAndExit.PerformStartupActions();
                Log.Info($"New session of REvernus has been successfully started.");
            }
            catch (Exception e)
            {
                Log.Fatal(e);
                Current.Shutdown();
            }
        }
    }
}
