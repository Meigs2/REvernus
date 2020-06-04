using REvernus.Utilities;
using System.Windows;
using System.Windows.Navigation;

namespace REvernus.Views.SimpleViews
{
    /// <summary>
    ///     Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox : Window
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Browser.OpenBrowser(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}