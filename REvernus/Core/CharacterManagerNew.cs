namespace REvernus.Core
{
    using System.Collections.Generic;

    using EVEStandard.Models.SSO;

    using REvernus.Models;

    public class CharacterManagerNew
    {
        public List<REvernusCharacter> Characters { get; set; }

        public bool AuthorizeNewCharacter()
        {
            return false;
        }

        public Authorization GenerateEsiAuthorization(List<string> scopes)
        {
            return null;
        }
    }
}