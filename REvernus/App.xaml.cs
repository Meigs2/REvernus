using log4net;
using Microsoft.EntityFrameworkCore;
using REvernus.Core;
using REvernus.Database.Contexts;
using REvernus.Properties;
using REvernus.Settings;
using REvernus.Utilities;
using REvernus.Utilities.StaticData;
using REvernus.Views.SimpleViews;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace REvernus
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static AppSettings Settings = new AppSettings();
        public static AuthProvider AuthProvider;
        public new static MainWindowView MainWindow { get; private set; }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            StartupComplete += PostStartupActions;

            Current.DispatcherUnhandledException += ApplicationDispatcherUnhandledException;

            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;

            await StartupActions();
        }

        private async Task StartupActions()
        {
            Logging.SetupLogging();

            DbChecks();

            TestEsiAndInternet();

            Services.Tracker.Track(Settings);

            EveItems.Initialize();

            AuthProvider = new AuthProvider();
            await AuthProvider.Initialize();

            OnStartupComplete();
        }

        private static void PostStartupActions(object sender, EventArgs e)
        {
            MainWindow = new MainWindowView();
            MainWindow.Show();
        }

        private void TestEsiAndInternet()
        {
        }

        private void ApplicationDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Fatal("An unhandled exception has not been caught inside the application and been thrown globally.",
                e.Exception);
#if DEBUG
            e.Handled = false;
#else
            ShowUnhandledException(e);
#endif
        }

        private void ShowUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            var errorMessage =
                "An unhandled exception has been thrown. Oh no! " +
                "If this error occurs again there seems to be a serious malfunction in REvernus. " +
                "Contact the devs on the discord when you see this, or if it keeps happening.\n\n" +
                $"Error: {e.Exception.Message + (e.Exception.InnerException != null ? "\n" + e.Exception.InnerException.Message : null)}\n\n" +
                "Do you wish to continue?" +
                "\n(if you click Yes REvernus will attempt to continue, if you click No the application will close)";

            if (MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.YesNoCancel,
                MessageBoxImage.Error) != MessageBoxResult.No) return;
            if (MessageBox.Show(
                    "WARNING: REvernus will close.\n" +
                    "Do you really want to exit?",
                    "Close REvernus?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) ==
                MessageBoxResult.Yes)
                Current.Shutdown();
        }

        private void DbChecks()
        {
            using var userContext = new UserContext();
            if (!File.Exists(Paths.UserDataBasePath))
            {
                Directory.CreateDirectory(Paths.DataFolderPath);
                // Ask to add a Developer Application.
                MessageBox.Show(
                    Strings.App_DbChecks_First_Run_Message_, Strings.App_DbChecks_Welcome_, MessageBoxButton.OK,
                    MessageBoxImage.Information);
                userContext.Database.Migrate();
                var window = new DeveloperApplicationDetailsWindow(userContext);
                window.ShowDialog();
                MessageBox.Show(Strings.App_DbChecks_Success_, Strings.REvernus_, MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            // Ensure the DB is created and up-to-date.
            userContext.Database.Migrate();
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
        }

        public event EventHandler StartupComplete;

        protected virtual void OnStartupComplete()
        {
            StartupComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}