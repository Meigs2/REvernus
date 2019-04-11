using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class SovereigntyStructure : ModelBase<SovereigntyStructure>
    {
        #region Properties

        /// <summary>
        /// The alliance that owns the structure. 
        /// </summary>
        /// <value>The alliance that owns the structure. </value>
        [JsonProperty("alliance_id")]
        public int AllianceId { get; set; }

        /// <summary>
        /// Solar system in which the structure is located. 
        /// </summary>
        /// <value>Solar system in which the structure is located. </value>
        [JsonProperty("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// Unique item ID for this structure.
        /// </summary>
        /// <value>Unique item ID for this structure.</value>
        [JsonProperty("structure_id")]
        public long StructureId { get; set; }

        /// <summary>
        /// A reference to the type of structure this is. 
        /// </summary>
        /// <value>A reference to the type of structure this is. </value>
        [JsonProperty("structure_type_id")]
        public int StructureTypeId { get; set; }

        /// <summary>
        /// The occupancy level for the next or current vulnerability window. This takes into account all development indexes and capital system bonuses. Also known as Activity Defense Multiplier from in the client. It increases the time that attackers must spend using their entosis links on the structure. 
        /// </summary>
        /// <value>The occupancy level for the next or current vulnerability window. This takes into account all development indexes and capital system bonuses. Also known as Activity Defense Multiplier from in the client. It increases the time that attackers must spend using their entosis links on the structure. </value>
        [JsonProperty("vulnerability_occupancy_level")]
        public float? VulnerabilityOccupancyLevel { get; set; }

        /// <summary>
        /// The time at which the next or current vulnerability window ends. At the end of a vulnerability window the next window is recalculated and locked in along with the vulnerabilityOccupancyLevel. If the structure is not in 100% entosis control of the defender, it will go in to &#39;overtime&#39; and stay vulnerable for as long as that situation persists. Only once the defenders have 100% entosis control and has the vulnerableEndTime passed does the vulnerability interval expire and a new one is calculated. 
        /// </summary>
        /// <value>The time at which the next or current vulnerability window ends. At the end of a vulnerability window the next window is recalculated and locked in along with the vulnerabilityOccupancyLevel. If the structure is not in 100% entosis control of the defender, it will go in to &#39;overtime&#39; and stay vulnerable for as long as that situation persists. Only once the defenders have 100% entosis control and has the vulnerableEndTime passed does the vulnerability interval expire and a new one is calculated. </value>
        [JsonProperty("vulnerable_end_time")]
        public DateTime? VulnerableEndTime { get; set; }

        /// <summary>
        /// The next time at which the structure will become vulnerable. Or the start time of the current window if current time is between this and vulnerableEndTime. 
        /// </summary>
        /// <value>The next time at which the structure will become vulnerable. Or the start time of the current window if current time is between this and vulnerableEndTime. </value>
        [JsonProperty("vulnerable_start_time")]
        public DateTime? VulnerableStartTime { get; set; }

        #endregion Properties
    }
}
