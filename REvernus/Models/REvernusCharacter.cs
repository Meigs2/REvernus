using System;
using System.Collections.Generic;
using System.Text;
using EVEStandard.Models.SSO;
using Prism.Mvvm;

namespace REvernus.Models
{
    public class REvernusCharacter
    {
        public AccessTokenDetails AccessTokenDetails { get; set; } = new AccessTokenDetails();
        public CharacterDetails CharacterDetails { get; set; } = new CharacterDetails();

        public string CharacterName => CharacterDetails.CharacterName;
    }
}
