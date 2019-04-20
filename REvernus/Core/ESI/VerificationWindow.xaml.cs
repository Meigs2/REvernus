using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EVEStandard;
using EVEStandard.Models.SSO;
using REvernus.Core.ESI;
using REvernus.Models;

namespace REvernus.Core.CharacterManagement
{
    /// <summary>
    /// Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        private EVEStandardAPI _client;
        public REvernusCharacter Character { get; set; } = new REvernusCharacter();
        private Authorization Authorization { get; set; } = new Authorization();

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public VerificationWindow(EVEStandardAPI client)
        {
            InitializeComponent();
            _client = client;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            Authorization = _client.SSOv2.AuthorizeToEVEUri(EsiScopes.Scopes);
            Utilities.Browser.OpenBrowser(Authorization.SignInURI);
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthCodeTextBox.Text == string.Empty) return;

                Authorization.AuthorizationCode = AuthCodeTextBox.Text;
                Authorization.ExpectedState = string.Empty; // Expected state is set to empty, as we don't require the user to provide it from the returned URL

                Character.AccessTokenDetails = await _client.SSOv2.VerifyAuthorizationAsync(Authorization);
                Character.CharacterDetails = _client.SSOv2.GetCharacterDetailsAsync(Character.AccessTokenDetails.AccessToken);

                Close();
            }
            catch (Exception error)
            {
                Log.Error(error);
                MessageBox.Show("Authorization verification failed, error message:\n" + error.Message +
                                "\n Source: \n" + error.Source + "\n\n Please click the image again and re-enter the code in the web prompt.");
            }
        }
    }
}
