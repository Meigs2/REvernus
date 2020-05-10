using System.Windows;
using System.Windows.Media;

namespace REvernus.Views
{
    /// <summary>
    /// Interaction logic for MarginToolView.xaml
    /// </summary>
    public partial class MarginToolView
    {
        public MarginToolView()
        {
            InitializeComponent();
        }

        private void OnTopCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(VisualTreeHelper.GetParent(this) ?? new Window());
            if (parentWindow != null) parentWindow.Topmost = !parentWindow.Topmost;
        }

        private void SampleDataCheckboxChecked(object sender, RoutedEventArgs e)
        {
            if (SampleDataGroupBox.Visibility == Visibility.Hidden)
            {
                SampleDataGroupBox.Visibility = Visibility.Visible;
                SampleDataRowDefinition.Height = new GridLength(4,GridUnitType.Star);
            }
            else
            {
                SampleDataGroupBox.Visibility = Visibility.Hidden;
                SampleDataRowDefinition.Height = new GridLength(0);
            }
        }
    }
}
