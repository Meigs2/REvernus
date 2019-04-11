using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterContactNotification : ModelBase<CharacterContactNotification>
    {
        #region Properties

        /// <summary>
        /// message string
        /// </summary>
        /// <value>message string</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// notification_id integer
        /// </summary>
        /// <value>notification_id integer</value>
        [JsonProperty("notification_id")]
        public int NotificationId { get; set; }

        /// <summary>
        /// send_date string
        /// </summary>
        /// <value>send_date string</value>
        [JsonProperty("send_date")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// sender_character_id integer
        /// </summary>
        /// <value>sender_character_id integer</value>
        [JsonProperty("sender_character_id")]
        public int SenderCharacterId { get; set; }

        /// <summary>
        /// A number representing the standing level the receiver has been added at by the sender. The standing levels are as follows: -10 -&gt; Terrible | -5 -&gt; Bad |  0 -&gt; Neutral |  5 -&gt; Good |  10 -&gt; Excellent
        /// </summary>
        /// <value>A number representing the standing level the receiver has been added at by the sender. The standing levels are as follows: -10 -&gt; Terrible | -5 -&gt; Bad |  0 -&gt; Neutral |  5 -&gt; Good |  10 -&gt; Excellent</value>
        [JsonProperty("standing_level")]
        public float StandingLevel { get; set; }

        #endregion Properties
    }
}
