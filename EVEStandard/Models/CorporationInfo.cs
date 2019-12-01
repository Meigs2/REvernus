using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class CorporationInfo : ModelBase<CorporationInfo>
    {
        #region Properties

        /// <summary>
        /// ID of the alliance that corporation is a member of, if any
        /// </summary>
        /// <value>ID of the alliance that corporation is a member of, if any</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// ceo_id integer
        /// </summary>
        /// <value>ceo_id integer</value>
        [JsonProperty("ceo_id")]
        public int CeoId { get; set; }

        /// <summary>
        /// creator_id integer
        /// </summary>
        /// <value>creator_id integer</value>
        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// date_founded string
        /// </summary>
        /// <value>date_founded string</value>
        [JsonProperty("date_founded")]
        public DateTime? DateFounded { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonProperty("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// home_station_id integer
        /// </summary>
        /// <value>home_station_id integer</value>
        [JsonProperty("home_station_id")]
        public int? HomeStationId { get; set; }

        /// <summary>
        /// member_count integer
        /// </summary>
        /// <value>member_count integer</value>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// the full name of the corporation
        /// </summary>
        /// <value>the full name of the corporation</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// shares integer
        /// </summary>
        /// <value>shares integer</value>
        [JsonProperty("shares")]
        public long? Shares { get; set; }

        /// <summary>
        /// tax_rate number
        /// </summary>
        /// <value>tax_rate number</value>
        [JsonProperty("tax_rate")]
        public float TaxRate { get; set; }

        /// <summary>
        /// the short name of the corporation
        /// </summary>
        /// <value>the short name of the corporation</value>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        /// <summary>
        /// url string
        /// </summary>
        /// <value>url string</value>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// war_eligible boolean
        /// </summary>
        /// <value>war_eligible boolean</value>
        [JsonProperty("war_eligible")]
        public bool WarEligible { get; set; }

        #endregion Properties
    }
}
