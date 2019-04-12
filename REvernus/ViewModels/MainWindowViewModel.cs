using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Navigation;
using Prism.Commands;
using REvernus.Core;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindowViewModel()
        {
            PerformStartup();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CharacterManagerMenuItemCommand = new DelegateCommand(OpenCharacterManagerWindow);
        }

        private void OpenCharacterManagerWindow()
        {
            Window w = new Window()
            {
                Title = "Character Manager",
                Content = new CharacterManagerView(),
                Width = 350,
                Height = 500,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            w.Show();
        }

        private static void PerformStartup()
        {
            try
            {
                Utilities.Startup.PerformStartupActions();
                Log.Info("New session of REvernus has been started.");
            }
            catch (Exception e)
            {
                Log.Fatal(e);
                Application.Current.Shutdown();
            }
        }

        public DelegateCommand CharacterManagerMenuItemCommand { get; set; }
    }
}
