using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace REvernus.Models
{
    public class CharacterManagerModel : BindableBase
    {
        public List<REvernusCharacter> _characters;
        public List<REvernusCharacter> Characters
        {
            get
            {
                if (_characters ==null)
                {
                    _characters = new List<REvernusCharacter>();
                }

                return _characters;
            }
            set => SetProperty(ref _characters, value);
        }
    }
}
