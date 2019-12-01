using REvernus.Settings;
using REvernus.Utilities;
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

        public static AppSettings Settings = new AppSettings();
        public new static MainWindowView MainWindow { get; private set; }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            await StartupAndExit.PerformStartupActions();

            MainWindow = new MainWindowView();
            MainWindow.Show();
        }
    }
}
