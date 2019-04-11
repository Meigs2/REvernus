using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class NewMail : ModelBase<NewMail>
    {
        #region Properties

        /// <summary>
        /// approved_cost integer
        /// </summary>
        /// <value>approved_cost integer</value>
        [JsonProperty("approved_cost")]
        public long? ApprovedCost { get; set; }

        /// <summary>
        /// body string
        /// </summary>
        /// <value>body string</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// recipients array
        /// </summary>
        /// <value>recipients array</value>
        [JsonProperty("recipients")]
        public List<MailRecipient> Recipients { get; set; }

        /// <summary>
        /// subject string
        /// </summary>
        /// <value>subject string</value>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        #endregion Properties
    }
}
