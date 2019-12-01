using System;
using System.Collections.Generic;

namespace REvernus.Models.SerializableModels
{
    [Serializable]
    public class SerializableList
    {
        public List<SerializableCharacter> SerializableCharacterList { get; set; } = new List<SerializableCharacter>();
    }
}
