using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class KillmailIndex : ModelBase<KillmailIndex>
    {
        #region Properties

        /// <summary>
        /// A hash of this killmail
        /// </summary>
        /// <value>A hash of this killmail</value>
        [JsonProperty("killmail_hash")]
        public string KillmailHash { get; set; }

        /// <summary>
        /// ID of this killmail
        /// </summary>
        /// <value>ID of this killmail</value>
        [JsonProperty("killmail_id")]
        public int KillmailId { get; set; }

        #endregion Properties
    }
}
