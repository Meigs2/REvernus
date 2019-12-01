using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class CorporationMemberTracking : ModelBase<CorporationMemberTracking>
    {
        #region Properties

        /// <summary>
        /// base_id integer
        /// </summary>
        /// <value>base_id integer</value>
        [JsonProperty("base_id")]
        public int? BaseId { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// logoff_date string
        /// </summary>
        /// <value>logoff_date string</value>
        [JsonProperty("logoff_date")]
        public DateTime? LogoffDate { get; set; }

        /// <summary>
        /// logon_date string
        /// </summary>
        /// <value>logon_date string</value>
        [JsonProperty("logon_date")]
        public DateTime? LogonDate { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonProperty("ship_type_id")]
        public int? ShipTypeId { get; set; }

        /// <summary>
        /// start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        #endregion Properties
    }
}
