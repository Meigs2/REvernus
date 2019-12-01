using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class FactionWarPilotLeaderboard : ModelBase<FactionWarPilotLeaderboard>
    {
        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonProperty("kills")]
        public FactionWarPilotTimeframe Kills { get; set; }

        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonProperty("victory_points")]
        public FactionWarPilotTimeframe VictoryPoints { get; set; }
    }

    public class FactionWarPilotTimeframe : ModelBase<FactionWarPilotTimeframe>
    {
        /// <summary>
        /// Top 4 ranking of factions in the past day
        /// </summary>
        /// <value>Top 4 ranking of factions in the past day</value>
        [JsonProperty("yesterday")]
        public List<FactionWarTopPilot> Yesterday { get; set; }

        /// <summary>
        /// Top 4 ranking of factions in the past week
        /// </summary>
        /// <value>Top 4 ranking of factions in the past week</value>
        [JsonProperty("last_week")]
        public List<FactionWarTopPilot> LastWeek { get; set; }

        /// <summary>
        /// Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.
        /// </summary>
        /// <value>Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.</value>
        [JsonProperty("active_total")]
        public List<FactionWarTopPilot> ActiveTotal { get; set; }
    }

    public class FactionWarTopPilot : ModelBase<FactionWarTopPilot>
    {
        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// Amount of kills
        /// </summary>
        /// <value>Amount of kills</value>
        [JsonProperty("amount")]
        public int? Amount { get; set; }
    }
}
