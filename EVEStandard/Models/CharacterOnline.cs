using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class CharacterOnline : ModelBase<CharacterOnline>
    {
        #region Properties

        /// <summary>
        /// Timestamp of the last login
        /// </summary>
        /// <value>Timestamp of the last login</value>
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Timestamp of the last logout
        /// </summary>
        /// <value>Timestamp of the last logout</value>
        [JsonProperty("last_logout")]
        public DateTime? LastLogout { get; set; }

        /// <summary>
        /// Total number of times the character has logged in
        /// </summary>
        /// <value>Total number of times the character has logged in</value>
        [JsonProperty("logins")]
        public int? Logins { get; set; }

        /// <summary>
        /// If the character is online
        /// </summary>
        /// <value>If the character is online</value>
        [JsonProperty("online")]
        public bool Online { get; set; }

        #endregion Properties
    }
}
