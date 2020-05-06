using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REvernus.Models.UserDbModels
{
    public class DeveloperApplication
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public string CallbackUrl { get; set; }
    }
}
