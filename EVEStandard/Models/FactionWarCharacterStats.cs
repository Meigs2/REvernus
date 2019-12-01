using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class FactionWarCharacterStats : ModelBase<FactionWarCharacterStats>
    {
        #region Properties

        /// <summary>
        /// The given character&#39;s current faction rank
        /// </summary>
        /// <value>The given character&#39;s current faction rank</value>
        [JsonProperty("current_rank")]
        public int? CurrentRank { get; set; }

        /// <summary>
        /// The enlistment date of the given character into faction warfare. Will not be included if character is not enlisted in faction warfare
        /// </summary>
        /// <value>The enlistment date of the given character into faction warfare. Will not be included if character is not enlisted in faction warfare</value>
        [JsonProperty("enlisted_on")]
        public DateTime? EnlistedOn { get; set; }

        /// <summary>
        /// The faction the given character is enlisted to fight for. Will not be included if character is not enlisted in faction warfare
        /// </summary>
        /// <value>The faction the given character is enlisted to fight for. Will not be included if character is not enlisted in faction warfare</value>
        [JsonProperty("faction_id")]
        public int? FactionId { get; set; }
        /// <summary>
        /// The given character&#39;s highest faction rank achieved
        /// </summary>
        /// <value>The given character&#39;s highest faction rank achieved</value>
        [JsonProperty("highest_rank")]
        public int? HighestRank { get; set; }

        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonProperty("kills")]
        public FactionWarCharacterStatsTimeframe Kills { get; set; }

        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonProperty("victory_points")]
        public FactionWarCharacterStatsTimeframe VictoryPoints { get; set; }

        #endregion Properties
    }

    public class FactionWarCharacterStatsTimeframe : ModelBase<FactionWarCharacterStatsTimeframe>
    {
        #region Properties

        /// <summary>
        /// Last week&#39;s victory points gained by the given character
        /// </summary>
        /// <value>Last week&#39;s victory points gained by the given character</value>
        [JsonProperty("last_week")] public int LastWeek { get; set; }

        /// <summary>
        /// Total victory points gained since the given character enlisted
        /// </summary>
        /// <value>Total victory points gained since the given character enlisted</value>
        [JsonProperty("total")] public int Total { get; set; }

        /// <summary>
        /// Yesterday&#39;s victory points gained by the given character
        /// </summary>
        /// <value>Yesterday&#39;s victory points gained by the given character</value>
        [JsonProperty("yesterday")] public int Yesterday { get; set; }

        #endregion Properties
    }
}
