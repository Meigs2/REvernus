using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Mail : ModelBase<Mail>
    {
        #region Properties

        /// <summary>
        /// From whom the mail was sent
        /// </summary>
        /// <value>From whom the mail was sent</value>
        [JsonProperty("from")]
        public int? From { get; set; }

        /// <summary>
        /// is_read boolean
        /// </summary>
        /// <value>is_read boolean</value>
        [JsonProperty("is_read")]
        public bool? IsRead { get; set; }

        /// <summary>
        /// labels array
        /// </summary>
        /// <value>labels array</value>
        [JsonProperty("labels")]
        public List<long?> Labels { get; set; }

        /// <summary>
        /// mail_id integer
        /// </summary>
        /// <value>mail_id integer</value>
        [JsonProperty("mail_id")]
        public long? MailId { get; set; }

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
