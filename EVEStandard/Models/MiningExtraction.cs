using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class MiningExtraction : ModelBase<MiningExtraction>
    {
        #region Properties

        /// <summary>
        /// The time at which the chunk being extracted will arrive and can be fractured by the moon mining drill. 
        /// </summary>
        /// <value>The time at which the chunk being extracted will arrive and can be fractured by the moon mining drill. </value>
        [JsonProperty("chunk_arrival_time")]
        public DateTime ChunkArrivalTime { get; set; }

        /// <summary>
        /// The time at which the current extraction was initiated. 
        /// </summary>
        /// <value>The time at which the current extraction was initiated. </value>
        [JsonProperty("extraction_start_time")]
        public DateTime ExtractionStartTime { get; set; }

        /// <summary>
        /// moon_id integer
        /// </summary>
        /// <value>moon_id integer</value>
        [JsonProperty("moon_id")]
        public int MoonId { get; set; }

        /// <summary>
        /// The time at which the chunk being extracted will naturally fracture if it is not first fractured by the moon mining drill. 
        /// </summary>
        /// <value>The time at which the chunk being extracted will naturally fracture if it is not first fractured by the moon mining drill. </value>
        [JsonProperty("natural_decay_time")]
        public DateTime NaturalDecayTime { get; set; }

        /// <summary>
        /// structure_id integer
        /// </summary>
        /// <value>structure_id integer</value>
        [JsonProperty("structure_id")]
        public long StructureId { get; set; }

        #endregion Properties
    }
}
