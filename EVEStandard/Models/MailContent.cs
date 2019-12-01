using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class MailContent : ModelBase<MailContent>
    {
        #region Properties

        /// <summary>
        /// Mail&#39;s body
        /// </summary>
        /// <value>Mail&#39;s body</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// From whom the mail was sent
        /// </summary>
        /// <value>From whom the mail was sent</value>
        [JsonProperty("from")]
        public int? From { get; set; }

        /// <summary>
        /// Labels attached to the mail
        /// </summary>
        /// <value>Labels attached to the mail</value>
        [JsonProperty("labels")]
        public List<long?> Labels { get; set; }

        /// <summary>
        /// Whether the mail is flagged as read
        /// </summary>
        /// <value>Whether the mail is flagged as read</value>
        [JsonProperty("read")]
        public bool? Read { get; set; }

        /// <summary>
        /// Recipients of the mail
        /// </summary>
        /// <value>Recipients of the mail</value>
        [JsonProperty("recipients")]
        public List<MailRecipient> Recipients { get; set; }

        /// <summary>
        /// Mail subject
        /// </summary>
        /// <value>Mail subject</value>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// When the mail was sent
        /// </summary>
        /// <value>When the mail was sent</value>
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        #endregion Properties
    }
}
