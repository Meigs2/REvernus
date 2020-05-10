namespace REvernus.Views.SimpleViews
{
    using System.Windows.Navigation;

    using REvernus.Utilities;

    /// <summary>
    ///     Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox
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