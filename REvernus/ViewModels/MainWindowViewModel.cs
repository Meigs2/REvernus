using Gma.System.MouseKeyHook;
using log4net;
using Prism.Commands;
using REvernus.Core;
using REvernus.Database.Contexts;
using REvernus.Utilities.StaticData;
using REvernus.Views;
using REvernus.Views.SimpleViews;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private Window _marginWindow;
        private int _numActiveJobs;

        private string _statusText;

        public MainWindowViewModel()
        {
            OpenCloseMarginToolCommand = new DelegateCommand(OpenCloseMarginTool);

            SubscribeHotKeys();
            AppDomain.CurrentDomain.ProcessExit += UnsubscribeHotKeys;
        }

        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                OnPropertyChanged();
            }
        }

        public int NumActiveJobs
        {
            get => _numActiveJobs;
            set
            {
                _numActiveJobs = value;
                OnPropertyChanged();
            }
        }

        private void OpenCloseMarginTool()
        {
            if (!App.MainWindow.IsActive && _marginWindow != null && !_marginWindow.IsActive) return;

            try
            {
                if (_marginWindow == null)
                {
                    _marginWindow = new Window
                    {
                        Title = "Margin Tool",
                        Content = new MarginToolView(),
                        Width = 430,
                        Height = 450,
                        WindowStartupLocation = WindowStartupLocation.Manual
                    };
                    _marginWindow.Show();
                    _marginWindow.Closing += (sender, args) =>
                    {
                        args.Cancel = true;
                        _marginWindow.Visibility = Visibility.Hidden;
                    };
                }
                else
                {
                    if (_marginWindow.WindowState == WindowState.Minimized)
                        _marginWindow.WindowState = WindowState.Normal;
                    else if (_marginWindow.Visibility == Visibility.Visible)
                        _marginWindow.Visibility = Visibility.Hidden;
                    else
                        _marginWindow.Visibility = Visibility.Visible;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
            }
        }

        private static void OpenDeveloperApplicationWindow()
        {
            var window = new DeveloperApplicationDetailsWindow(new UserContext());
            window.Show();
        }

        private static void OpenCharacterManagerWindow()
        {
            try
            {
                var w = new Window
                {
                    Title = "Character Manager",
                    Content = new CharacterManagerView(),
                    Width = 350,
                    Height = 500,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                w.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
            }
        }

        private static void OpenStructureManagerWindow()
        {
            StructureManager.ShowStructureManagementWindow();
        }

        private static void CloseMainWindow()
        {
            Environment.Exit(0);
        }

        private static void OpenAboutBox()
        {
            var a = new AboutBox();
            a.Show();
        }

        private static void OpenSettingsView()
        {
            if (!App.MainWindow.IsActive) return;

            var a = new SettingsManagerView();
            a.ShowDialog();
        }

        private static void OpenItemExporter()
        {
            var window = new ItemExporterView();
            window.ShowDialog();
        }

        #region HotKeys

        private IKeyboardMouseEvents _keybindEvents = Hook.AppEvents();

        private void UnsubscribeHotKeys(object sender, EventArgs e)
        {
            _keybindEvents.Dispose();
        }

        private void UnsubscribeHotKeys()
        {
            _keybindEvents.Dispose();
        }

        private void SubscribeHotKeys()
        {
            UnsubscribeHotKeys();

            _keybindEvents = Hook.GlobalEvents();

            var actions = new Dictionary<Combination, Action>
            {
                {Combination.FromString("Control+M"), OpenCloseMarginTool}
            };

            _keybindEvents.OnCombination(actions);
        }

        #endregion


        #region Delegates

        public DelegateCommand OpenCloseMarginToolCommand { get; set; }

        public DelegateCommand CharacterManagerMenuItemCommand { get; set; } =
            new DelegateCommand(OpenCharacterManagerWindow);

        public DelegateCommand AboutBoxOpenCommand { get; set; } = new DelegateCommand(OpenAboutBox);

        public DelegateCommand OpenStructureManagerCommand { get; set; } =
            new DelegateCommand(OpenStructureManagerWindow);

        public DelegateCommand CloseMainWindowCommand { get; set; } = new DelegateCommand(CloseMainWindow);
        public DelegateCommand OpenSettingsViewCommand { get; set; } = new DelegateCommand(OpenSettingsView);

        public DelegateCommand DownloadSdeDataMenuItemCommand { get; set; } = new DelegateCommand(async () =>
        {
            var downloader = new SdeDownloader();
            await downloader.DownloadLatestSde();
        });

        public DelegateCommand OpenDeveloperApplicationWindowCommand { get; set; } =
            new DelegateCommand(OpenDeveloperApplicationWindow);

        public DelegateCommand OpenItemExplorerCommand { get; set; } = new DelegateCommand(OpenItemExporter);

        #endregion
    }
}