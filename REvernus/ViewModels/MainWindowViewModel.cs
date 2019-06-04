using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Navigation;
using Prism.Commands;
using REvernus.Core;
using REvernus.Models;
using REvernus.Utilities;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public REvernusCharacter SelectedCharacter
        {
            get => CharacterManager.CurrentInstance.SelectedCharacter;
            set
            {
                CharacterManager.CurrentInstance.SelectedCharacter = value;
                OnPropertyChanged();
            }
        }

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CharacterManagerMenuItemCommand = new DelegateCommand(OpenCharacterManagerWindow);
            DownloadSdeDataMenuItemCommand = new DelegateCommand(() =>
            {
                var dl = new SdeDownloader();
                dl.DownloadLatestSde();
            });
        }

        private static void OpenCharacterManagerWindow()
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

        public DelegateCommand CharacterManagerMenuItemCommand { get; set; }
        public DelegateCommand DownloadSdeDataMenuItemCommand { get; set; }
    }
}