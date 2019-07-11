using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using REvernus.ViewModels;

namespace REvernus.Utilities
{
    public static class Status
    {
        public static void SetStatusText(string text)
        {
            if (App.MainWindow.DataContext is MainWindowViewModel viewModel) viewModel.StatusText = text;
        }
        public static void SetStatusText()
        {
            if (App.MainWindow.DataContext is MainWindowViewModel viewModel) viewModel.StatusText = "";
        }
    }
}
