using REvernus.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Models.UserDbModels;
using REvernus.Properties;
using REvernus.Settings;
using REvernus.Utilities.StaticData;
using REvernus.Views.SimpleViews;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

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
        public static CharacterManager CharacterManager;
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

            // Check if first execution

            DbChecks();

            // Check if internet has connection(?)

            CharacterManager = new CharacterManager();

            EveItems.Initialize();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        private void DbChecks()
        {
            using var userContext = new UserContext();
            // Odds are, if 
            if (!File.Exists(Paths.UserDataBasePath))
            {
                // Ask to add Developer Application
                MessageBox.Show(
                    Strings.App_DbChecks_First_Run_Message_, Strings.App_DbChecks_Welcome_, MessageBoxButton.OK, MessageBoxImage.Information);
                userContext.Database.Migrate();
                var window = new DeveloperApplicationDetailsWindow(userContext);
                window.ShowDialog();
                // Check if information has been entered
                // Should eventually be refactored to remove .GetAwaiter()
                if (Task.Run(() => EsiData.EsiClient.Status.GetStatusV1Async()).GetAwaiter().GetResult().RemainingErrors > 0)
                {
                    Environment.Exit(-100);
                }
                else
                {
                    MessageBox.Show(Strings.App_DbChecks_Success_, Strings.REvernus_, MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            // Ensure the DB is created and up-to-date.
            userContext.Database.Migrate();
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {

        }
    }
}
