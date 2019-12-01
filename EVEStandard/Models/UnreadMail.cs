using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class MailLabel : ModelBase<MailLabel>
    {
        #region Properties

        /// <summary>
        /// color string
        /// </summary>
        /// <value>color string</value>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// label_id integer
        /// </summary>
        /// <value>label_id integer</value>
        [JsonProperty("label_id")]
        public int? LabelId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// unread_count integer
        /// </summary>
        /// <value>unread_count integer</value>
        [JsonProperty("unread_count")]
        public int? UnreadCount { get; set; }

        #endregion Properties
    }

    public class UnreadMail : ModelBase<UnreadMail>
    {
        #region Properties

        /// <summary>
        /// labels array
        /// </summary>
        /// <value>labels array</value>
        [JsonProperty("labels")]
        public List<MailLabel> Labels { get; set; }

        /// <summary>
        /// total_unread_count integer
        /// </summary>
        /// <value>total_unread_count integer</value>
        [JsonProperty("total_unread_count")]
        public int? TotalUnreadCount { get; set; }

        #endregion Properties
    }
}
