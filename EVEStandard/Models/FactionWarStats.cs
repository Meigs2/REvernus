using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class FactionWarStats : ModelBase<FactionWarStats>
    {
        #region Properties

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonProperty("faction_id")]
        public int FactionId { get; set; }

        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonProperty("kills")]
        public FwStatsKills Kills { get; set; }

        /// <summary>
        /// How many pilots fight for the given faction
        /// </summary>
        /// <value>How many pilots fight for the given faction</value>
        [JsonProperty("pilots")]
        public int Pilots { get; set; }

        /// <summary>
        /// The number of solar systems controlled by the given faction
        /// </summary>
        /// <value>The number of solar systems controlled by the given faction</value>
        [JsonProperty("systems_controlled")]
        public int SystemsControlled { get; set; }
        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonProperty("victory_points")]
        public FwStatsVictoryPoints VictoryPoints { get; set; }

        #endregion Properties
    }

    public class FwStatsKills : ModelBase<FwStatsKills>
    {
        #region Properties

        /// <summary>
        /// Last week&#39;s total number of kills against enemy factions
        /// </summary>
        /// <value>Last week&#39;s total number of kills against enemy factions</value>
        [JsonProperty("last_week")] public int LastWeek { get; set; }

        /// <summary>
        /// Total number of kills against enemy factions since faction warfare began
        /// </summary>
        /// <value>Total number of kills against enemy factions since faction warfare began</value>
        [JsonProperty("total")] public int Total { get; set; }

        /// <summary>
        /// Yesterday&#39;s total number of kills against enemy factions
        /// </summary>
        /// <value>Yesterday&#39;s total number of kills against enemy factions</value>
        [JsonProperty("yesterday")] public int Yesterday { get; set; }

        #endregion Properties
    }

    public class FwStatsVictoryPoints : ModelBase<FwStatsVictoryPoints>
    {
        #region Properties

        /// <summary>
        /// Last week&#39;s victory points gained
        /// </summary>
        /// <value>Last week&#39;s victory points gained</value>
        [JsonProperty("last_week")] public int LastWeek { get; set; }

        /// <summary>
        /// Total victory points gained since faction warfare began
        /// </summary>
        /// <value>Total victory points gained since faction warfare began</value>
        [JsonProperty("total")] public int Total { get; set; }

        /// <summary>
        /// Yesterday&#39;s victory points gained
        /// </summary>
        /// <value>Yesterday&#39;s victory points gained</value>
        [JsonProperty("yesterday")] public int Yesterday { get; set; }

        #endregion Properties
    }
}
