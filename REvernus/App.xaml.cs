namespace REvernus
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows;

    using log4net;

    using Microsoft.EntityFrameworkCore;

    using REvernus.Core;
    using REvernus.Core.ESI;
    using REvernus.Database.Contexts;
    using REvernus.Properties;
    using REvernus.Settings;
    using REvernus.Utilites;
    using REvernus.Utilities;
    using REvernus.Utilities.StaticData;
    using REvernus.Views;
    using REvernus.Views.SimpleViews;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static CharacterManager CharacterManager;

        // ReSharper disable once UnusedMember.Local
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly AppSettings Settings = new AppSettings();
        public new static MainWindowView MainWindow { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            StartupActions();

            MainWindow = new MainWindowView();
            MainWindow.Show();
        }

        private void DbChecks()
        {
            using var userContext = new UserContext();
            // Odds are, if 
            if (!File.Exists(Paths.UserDataBasePath))
            {
                // Ask to add Developer Application
                MessageBox.Show(
                    Strings.App_DbChecks_First_Run_Message_, Strings.App_DbChecks_Welcome_, MessageBoxButton.OK,
                    MessageBoxImage.Information);
                userContext.Database.Migrate();
                var window = new DeveloperApplicationDetailsWindow(userContext);
                window.ShowDialog();
                // Check if information has been entered
                // Should eventually be refactored to remove .GetAwaiter()
                if (Task.Run(() => EsiData.EsiClient.Status.GetStatusV1Async()).GetAwaiter().GetResult()
                    .RemainingErrors > 0)
                    Environment.Exit(-100);
                else
                    MessageBox.Show(Strings.App_DbChecks_Success_, Strings.REvernus_, MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }

            // Ensure the DB is created and up-to-date.
            userContext.Database.Migrate();
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
        }

        private void StartupActions()
        {
            Logging.SetupLogging();

            Services.Tracker.Track(Settings);

            // Check if first execution

            DbChecks();

            // Check if internet has connection(?)

            CharacterManager = new CharacterManager();

            EveItems.Initialize();

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }
    }
}