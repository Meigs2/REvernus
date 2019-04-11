using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class UpdateMailMetadata : ModelBase<UpdateMailMetadata>
    {
        #region Properties

        /// <summary>
        /// Labels to assign to the mail. Pre-existing labels are unassigned.
        /// </summary>
        /// <value>Labels to assign to the mail. Pre-existing labels are unassigned.</value>
        [JsonProperty("labels")]
        public List<long> Labels { get; set; }

        /// <summary>
        /// Whether the mail is flagged as read
        /// </summary>
        /// <value>Whether the mail is flagged as read</value>
        [JsonProperty("read")]
        public bool? Read { get; set; }

        #endregion Properties
    }
}
