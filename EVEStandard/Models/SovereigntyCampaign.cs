using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class SovereigntyCampaign : ModelBase<SovereigntyCampaign>
    {
        #region Enums

        /// <summary>
        /// Type of event this campaign is for. tcu_defense, ihub_defense and station_defense are referred to as \"Defense Events\", station_freeport as \"Freeport Events\". 
        /// </summary>
        /// <value>Type of event this campaign is for. tcu_defense, ihub_defense and station_defense are referred to as \"Defense Events\", station_freeport as \"Freeport Events\". </value>
        public enum EventTypeEnum
        {
            tcu_defense = 1,
            ihub_defense = 2,
            station_defense = 3,
            station_freeport = 4
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Score for all attacking parties, only present in Defense Events. 
        /// </summary>
        /// <value>Score for all attacking parties, only present in Defense Events. </value>
        [JsonProperty("attackers_score")]
        public float? AttackersScore { get; set; }

        /// <summary>
        /// Unique ID for this campaign.
        /// </summary>
        /// <value>Unique ID for this campaign.</value>
        [JsonProperty("campaign_id")]
        public int CampaignId { get; set; }

        /// <summary>
        /// The constellation in which the campaign will take place. 
        /// </summary>
        /// <value>The constellation in which the campaign will take place. </value>
        [JsonProperty("constellation_id")]
        public int ConstellationId { get; set; }

        /// <summary>
        /// Defending alliance, only present in Defense Events 
        /// </summary>
        /// <value>Defending alliance, only present in Defense Events </value>
        [JsonProperty("defender_id")]
        public int? DefenderId { get; set; }

        /// <summary>
        /// Score for the defending alliance, only present in Defense Events. 
        /// </summary>
        /// <value>Score for the defending alliance, only present in Defense Events. </value>
        [JsonProperty("defender_score")]
        public float? DefenderScore { get; set; }

        /// <summary>
        /// Type of event this campaign is for. tcu_defense, ihub_defense and station_defense are referred to as \&quot;Defense Events\&quot;, station_freeport as \&quot;Freeport Events\&quot;. 
        /// </summary>
        /// <value>Type of event this campaign is for. tcu_defense, ihub_defense and station_defense are referred to as \&quot;Defense Events\&quot;, station_freeport as \&quot;Freeport Events\&quot;. </value>
        [JsonProperty("event_type")]
        public EventTypeEnum EventType { get; set; }

        /// <summary>
        /// Alliance participating and their respective scores, only present in Freeport Events. 
        /// </summary>
        /// <value>Alliance participating and their respective scores, only present in Freeport Events. </value>
        [JsonProperty("participants")]
        public List<SovereigntyCampaignsParticipant> Participants { get; set; }

        /// <summary>
        /// The solar system the structure is located in. 
        /// </summary>
        /// <value>The solar system the structure is located in. </value>
        [JsonProperty("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// Time the event is scheduled to start. 
        /// </summary>
        /// <value>Time the event is scheduled to start. </value>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The structure item ID that is related to this campaign. 
        /// </summary>
        /// <value>The structure item ID that is related to this campaign. </value>
        [JsonProperty("structure_id")]
        public long StructureId { get; set; }

        #endregion Properties
    }

    public class SovereigntyCampaignsParticipant : ModelBase<SovereigntyCampaignsParticipant>
    {
        #region Properties

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// score number
        /// </summary>
        /// <value>score number</value>
        [JsonProperty("score")]
        public float? Score { get; set; }

        #endregion Properties
    }
}
