using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class MailList : ModelBase<MailList>
    {
        /// <summary>
        /// Mailing list ID
        /// </summary>
        /// <value>Mailing list ID</value>
        [JsonProperty("mailing_list_id")]
        public int MailingListId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
