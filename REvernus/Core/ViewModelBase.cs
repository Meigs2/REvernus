using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace REvernus.Core
{
    /// <summary>
    /// This class implements the INotifyPropertyChanged interface, and should be used for ViewModels
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
