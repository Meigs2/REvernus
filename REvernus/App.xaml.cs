using REvernus.Utilities;
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using REvernus.Core;
using REvernus.Models.UserDbModels;
using REvernus.Settings;
using REvernus.Utilities.StaticData;

namespace REvernus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static AppSettings Settings = new AppSettings();
        public new static MainWindowView MainWindow { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            StartupActions();

            MainWindow = new MainWindowView();
            MainWindow.Show();
        }

        private void StartupActions()
        {
            Logging.SetupLogging();

            Services.Tracker.Track(App.Settings);

            DbChecks();

            EveItems.Initialize();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        private void DbChecks()
        {
            // Ensure the DB is created and up-to-date.
            var a = new UserContext();
            a.Database.Migrate();
            a.Dispose();
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {

        }
    }
}
