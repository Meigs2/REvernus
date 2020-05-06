using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REvernus.Models.UserDbModels
{
    public class CharacterInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string RefreshToken { get; set; }
    }
}
