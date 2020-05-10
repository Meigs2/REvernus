namespace REvernus.Views.SimpleViews
{
    using System;
    using System.Reflection;
    using System.Windows;

    using EVEStandard;
    using EVEStandard.Models.SSO;

    using log4net;

    using REvernus.Core.ESI;
    using REvernus.Models;
    using REvernus.Utilities;

    /// <summary>
    ///     Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow
    {
        // ReSharper disable once PossibleNullReferenceException
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly EVEStandardAPI _client;

        public VerificationWindow(EVEStandardAPI client)
        {
            InitializeComponent();
            _client = client;
        }

        private Authorization Authorization { get; set; } = new Authorization();
        public REvernusCharacter Character { get; } = new REvernusCharacter();

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthCodeTextBox.Text == string.Empty)
                    return;

                Authorization.AuthorizationCode = AuthCodeTextBox.Text.Trim();
                Authorization.ExpectedState =
                    string.Empty; // Expected state is set to empty, as we don't require the user to provide it from the returned URL

                Character.AccessTokenDetails = await _client.SSO.VerifyAuthorizationAsync(Authorization);
                Character.CharacterDetails =
                    await _client.SSO.GetCharacterDetailsAsync(Character.AccessTokenDetails.AccessToken);

                Close();
            }
            catch (Exception error)
            {
                Log.Error(error);
                MessageBox.Show("Authorization verification failed, error message:\n" + error.Message +
                                "\n Source: \n" + error.Source +
                                "\n\n Please click the image again and re-enter the code in the web prompt.");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            Authorization = _client.SSO.AuthorizeToEVEUri(EsiScopes.Scopes);
            Browser.OpenBrowser(Authorization.SignInURI);
        }
    }
}