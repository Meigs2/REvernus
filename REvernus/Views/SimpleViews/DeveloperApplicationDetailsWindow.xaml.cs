using REvernus.Database.Contexts;
using REvernus.Database.UserDbModels;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace REvernus.Views.SimpleViews
{
    /// <summary>
    ///     Interaction logic for DeveloperApplicationDetailsWindow.xaml
    /// </summary>
    public partial class DeveloperApplicationDetailsWindow : Window
    {
        private readonly UserContext _userContext;
        private bool _saveData;

        public DeveloperApplicationDetailsWindow(UserContext userContext)
        {
            InitializeComponent();
            _userContext = userContext;
            Loaded += OnLoaded;
            Closing += OnClosing;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!_userContext.DeveloperApplications.Any())
            {
                CallbackUrlTextBox.Text = @"https://meigs2.github.io/ESICallback/";
            }
            else
            {
                var a = _userContext.DeveloperApplications.Select(o => o).FirstOrDefault();
                if (a == null) return;
                ClientIdTextBox.Text = a.ClientId;
                SecretKeyTextBox.Password = a.SecretKey;
                CallbackUrlTextBox.Text = a.CallbackUrl;
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (_saveData)
            {
                if (!ClientIdTextBox.Text.Equals("") && !SecretKeyTextBox.Password.Equals("") &&
                    !CallbackUrlTextBox.Text.Equals(""))
                {
                    _userContext.DeveloperApplications.RemoveRange(_userContext.DeveloperApplications);
                    _userContext.DeveloperApplications.Add(new DeveloperApplication
                    {
                        ClientId = ClientIdTextBox.Text.Trim(),
                        SecretKey = SecretKeyTextBox.Password.Trim(),
                        CallbackUrl = CallbackUrlTextBox.Text
                    });
                    _userContext.SaveChanges();
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("One of the fields is empty. Please enter data into all fields before saving.");
                    _saveData = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _saveData = true;
            Close();
        }
    }
}