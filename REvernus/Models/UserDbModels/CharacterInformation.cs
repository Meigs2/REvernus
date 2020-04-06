using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

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
