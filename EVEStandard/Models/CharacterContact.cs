using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterContact : ModelBase<CharacterContact>
    {
        #region Properties

        /// <summary>
        /// contact_id integer
        /// </summary>
        /// <value>contact_id integer</value>
        [JsonProperty("contact_id")]
        public int ContactId { get; set; }

        /// <summary>
        /// contact_type string
        /// </summary>
        /// <value>contact_type string</value>
        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        /// <summary>
        /// Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false
        /// </summary>
        /// <value>Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false</value>
        [JsonProperty("is_blocked")]
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Whether this contact is being watched
        /// </summary>
        /// <value>Whether this contact is being watched</value>
        [JsonProperty("is_watched")]
        public bool? IsWatched { get; set; }

        /// <summary>
        /// Custom label of the contact
        /// </summary>
        /// <value>Custom label of the contact</value>
        [JsonProperty("label_ids")]
        public List<long> LabelIds { get; set; }

        /// <summary>
        /// Standing of the contact
        /// </summary>
        /// <value>Standing of the contact</value>
        [JsonProperty("standing")]
        public float Standing { get; set; }

        #endregion Properties
    }
}
