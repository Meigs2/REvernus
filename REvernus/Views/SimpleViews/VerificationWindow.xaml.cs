using System;
using System.Windows;
using EVEStandard;
using EVEStandard.Models.SSO;
using REvernus.Core.ESI;
using REvernus.Models;

namespace REvernus.Views.SimpleViews
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
            Authorization = _client.SSO.AuthorizeToEVEUri(EsiScopes.Scopes);
            Utilities.Browser.OpenBrowser(Authorization.SignInURI);
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthCodeTextBox.Text == string.Empty) return;

                Authorization.AuthorizationCode = AuthCodeTextBox.Text;
                Authorization.ExpectedState = string.Empty; // Expected state is set to empty, as we don't require the user to provide it from the returned URL

                Character.AccessTokenDetails = await _client.SSO.VerifyAuthorizationAsync(Authorization);
                Character.CharacterDetails = await _client.SSO.GetCharacterDetailsAsync(Character.AccessTokenDetails.AccessToken);

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
