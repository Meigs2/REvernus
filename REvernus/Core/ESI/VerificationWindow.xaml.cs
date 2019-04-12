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
using MEvernus.Core.ESI;
using REvernus.Models;

namespace MEvernus.Core.CharacterManagement
{
    /// <summary>
    /// Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        private readonly EVEStandardAPI _client;
        public EvernusCharacter Character { get; set; } = new EvernusCharacter();
        private Authorization Authorization { get; set; }

        public VerificationWindow(EVEStandardAPI client)
        {
            InitializeComponent();
            _client = client;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            Authorization = _client.SSO.AuthorizeToEVEUri(EsiScopes.Scopes);
            Process.Start(Authorization.SignInURI);
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

                // If this character is already added to our list, ask if we want to replace it.
                if (CharacterManager.CurrentInstance.CharacterList.SingleOrDefault(c => c.CharacterName == Character.CharacterName) != null)
                {
                    var duplicate =
                        CharacterManager.CurrentInstance.CharacterList.Single(c =>
                            c.CharacterName == Character.CharacterName);
                    var dialogResult = MessageBox.Show("Character is already added, would you like to replace it?", "", MessageBoxButton.YesNo);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        CharacterManager.CurrentInstance.CharacterList[
                                CharacterManager.CurrentInstance.CharacterList.IndexOf(duplicate)] =
                            Character;
                        Close();
                        return;
                    }
                    else
                    {
                        Close();
                        return;
                    }
                }

                CharacterManager.CurrentInstance.CharacterList.Add(Character);
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Authorization verification failed, error message:\n" + error.Message +
                                "\n Source: \n" + error.Source + "\n\n Please click the image again and re-enter the code in the web prompt.");
            }
        }
    }
}
