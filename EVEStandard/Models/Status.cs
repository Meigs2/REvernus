using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Status : ModelBase<Status>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        [JsonProperty("players")]
        public int Players { get; set; }

        /// <summary>
        /// Gets or sets the server version.
        /// </summary>
        /// <value>
        /// The server version.
        /// </value>
        [JsonProperty("server_version")]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Status"/> is vip.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vip; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("vip")]
        public bool? VIP { get; set; }

        #endregion Properties
    }
}