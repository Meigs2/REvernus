using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class SystemKills : ModelBase<SystemKills>
    {
        #region Properties

        /// <summary>
        /// Number of NPC ships killed in this system
        /// </summary>
        /// <value>Number of NPC ships killed in this system</value>
        [JsonProperty("npc_kills")]
        public int NpcKills { get; set; }

        /// <summary>
        /// Number of pods killed in this system
        /// </summary>
        /// <value>Number of pods killed in this system</value>
        [JsonProperty("pod_kills")]
        public int PodKills { get; set; }

        /// <summary>
        /// Number of player ships killed in this system
        /// </summary>
        /// <value>Number of player ships killed in this system</value>
        [JsonProperty("ship_kills")]
        public int ShipKills { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
