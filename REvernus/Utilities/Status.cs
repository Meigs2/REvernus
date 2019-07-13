using System;
using REvernus.ViewModels;
using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Threading;

namespace REvernus.Utilities
{
    public class Status
    {
        private static readonly ConcurrentDictionary<StatusHandle, StatusHandle> StatusDictionary = new ConcurrentDictionary<StatusHandle, StatusHandle>();

        protected static string StatusText
        {
            get
            {
                if (App.MainWindow.DataContext is MainWindowViewModel viewModel)
                {
                    return viewModel.StatusText;
                }
                return "";
            }
            set
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (App.MainWindow.DataContext is MainWindowViewModel viewModel) viewModel.StatusText = value;
                });
            }
        }

        public static StatusHandle GetNewStatusHandle()
        {
            var handle = new StatusHandle();
            StatusDictionary.TryAdd(handle, handle);
            StatusText = $"Number of active jobs: {StatusDictionary.Count}";
            return handle;
        }

        protected void DisposeHandle(StatusHandle handle)
        {
            StatusDictionary.TryRemove(handle, out _);
            StatusText = StatusDictionary.Count > 0 ? $"Number of active jobs: {StatusDictionary.Count}" : "";
        }
    }
}
