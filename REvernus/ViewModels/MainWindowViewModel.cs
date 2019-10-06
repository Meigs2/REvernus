using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Gma.System.MouseKeyHook;
using Jot;
using Prism.Commands;
using REvernus.Core;
using REvernus.Models;
using REvernus.Utilities;
using REvernus.Utilities.StaticData;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public REvernusCharacter SelectedCharacter
        {
            get => CharacterManager.SelectedCharacter;
            set
            {
                CharacterManager.SelectedCharacter = value;
                OnPropertyChanged();
            }
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

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _statusText;
        private int _numActiveJobs;

        public MainWindowViewModel()
        {
            OpenCloseMarginToolCommand = new DelegateCommand(OpenCloseMarginTool);

            SubscribeHotKeys();
            AppDomain.CurrentDomain.ProcessExit += UnsubscribeHotKeys;
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

            var actions = new Dictionary<Combination, Action>()
            {
                {Combination.FromString("Control+M"), OpenCloseMarginTool},
            };

            _keybindEvents.OnCombination(actions);
        }

        #endregion

        private Window _marginWindow;

        private void OpenCloseMarginTool()
        {
            if (!App.MainWindow.IsActive && (_marginWindow != null && !_marginWindow.IsActive)) return;

            try
            {
                if (_marginWindow == null)
                {
                    _marginWindow = new Window()
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
                    {
                        _marginWindow.WindowState = WindowState.Normal;
                    }
                    else if (_marginWindow.Visibility == Visibility.Visible)
                    {
                        _marginWindow.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        _marginWindow.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
            }
        }

        private static void OpenCharacterManagerWindow()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
            }
        }

        public DelegateCommand OpenCloseMarginToolCommand { get; set; }

        public DelegateCommand CharacterManagerMenuItemCommand { get; set; } = new DelegateCommand(OpenCharacterManagerWindow);
        public DelegateCommand DownloadSdeDataMenuItemCommand { get; set; } = new DelegateCommand(async () =>
        {
            var downloader = new SdeDownloader();
            await downloader.DownloadLatestSde();
        });

        public DelegateCommand OpenCitadelManagerCommand { get; set; } = new DelegateCommand(OpenCitadelManagerWindow);

        private static void OpenCitadelManagerWindow()
        {
            CitadelManager.ShowCitadelManagementWindow();
        }

        public DelegateCommand AboutBoxOpenCommand { get; set; } = new DelegateCommand(OpenAboutBox);

        private static void OpenAboutBox()
        {
            var a = new Views.SimpleViews.AboutBox();
            a.Show();
        }
    }
}