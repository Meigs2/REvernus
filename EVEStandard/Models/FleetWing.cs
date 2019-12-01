using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class FleetWing : ModelBase<FleetWing>
    {
        #region Properties

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// squads array
        /// </summary>
        /// <value>squads array</value>
        [JsonProperty("squads")]
        public List<FleetSquad> Squads { get; set; }

        #endregion Properties
    }

    public class FleetSquad : ModelBase<FleetSquad>
    {
        #region Properties

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")] public long Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")] public string Name { get; set; }

        #endregion Properties
    }
}
