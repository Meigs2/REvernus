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
            // Bug: .Net Core 3.0 Preview 4/5 has a DPI scaling issue, this fixes it. To be removed when fixed.
            var bugWindow = new Window
            {
                Height = 0,
                ShowInTaskbar = false,
                Width = 0,
                WindowStyle = WindowStyle.None
            };
            bugWindow.Show();
            bugWindow.Hide();

            await PerformStartupActions();

            // Start the Main Window.
            var mainWindowView = new MainWindowView();
            mainWindowView.ShowDialog();
            Current.Shutdown(-1);
        }

        private static async Task PerformStartupActions()
        {
            try
            {
                await Utilities.StartupAndExit.PerformStartupActions();
                Log.Info("New session of REvernus has been successfully started.");
            }
            catch (Exception e)
            {
                Log.Fatal(e);
                Current.Shutdown();
            }
        }
    }
}
