using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace REvernus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await PerformStartupActions();

            // Start the Main Window.
            var a = new MainWindowView();
            a.Show();
        }

        private static async Task PerformStartupActions()
        {
            try
            {
                await Utilities.StartupAndExit.PerformStartupActions();
                Log.Info("New session of REvernus has been started.");
            }
            catch (Exception e)
            {
                Log.Fatal(e);
                Current.Shutdown();
            }
        }
    }
}
