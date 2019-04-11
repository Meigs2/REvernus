using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Constellation : ModelBase<Constellation>
    {
        #region Properties

        /// <summary>
        /// constellation_id integer
        /// </summary>
        /// <value>constellation_id integer</value>
        [JsonProperty("constellation_id")]
        public int ConstellationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The region this constellation is in
        /// </summary>
        /// <value>The region this constellation is in</value>
        [JsonProperty("region_id")]
        public int RegionId { get; set; }

        /// <summary>
        /// systems array
        /// </summary>
        /// <value>systems array</value>
        [JsonProperty("systems")]
        public List<int> Systems { get; set; }

        #endregion Properties
    }
}
