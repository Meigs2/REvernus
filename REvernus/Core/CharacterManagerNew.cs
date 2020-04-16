using System;
using System.Collections.Generic;
using System.Text;
using EVEStandard;
using EVEStandard.Models.SSO;
using REvernus.Models;

namespace REvernus.Core
{
    public class CharacterManagerNew
    {
        public List<REvernusCharacter> Characters { get; set; }

        public CharacterManagerNew()
        {

        }

        public Authorization GenerateEsiAuthorization(List<string> scopes)
        {
            return null;
        }

        public bool AuthorizeNewCharacter()
        {
            return false;
        }
    }
}
