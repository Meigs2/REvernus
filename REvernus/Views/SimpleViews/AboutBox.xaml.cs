using System.Windows.Navigation;

namespace REvernus.Views.SimpleViews
{
    /// <summary>
    /// Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Utilities.Browser.OpenBrowser(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
