using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class Search : ModelBase<Search>
    {
        #region Properties

        /// <summary>
        /// agent array
        /// </summary>
        /// <value>agent array</value>
        [JsonProperty("agent")]
        public List<int> Agent { get; set; }

        /// <summary>
        /// alliance array
        /// </summary>
        /// <value>alliance array</value>
        [JsonProperty("alliance")]
        public List<int> Alliance { get; set; }

        /// <summary>
        /// character array
        /// </summary>
        /// <value>character array</value>
        [JsonProperty("character")]
        public List<int> Character { get; set; }

        /// <summary>
        /// constellation array
        /// </summary>
        /// <value>constellation array</value>
        [JsonProperty("constellation")]
        public List<int> Constellation { get; set; }

        /// <summary>
        /// corporation array
        /// </summary>
        /// <value>corporation array</value>
        [JsonProperty("corporation")]
        public List<int> Corporation { get; set; }

        /// <summary>
        /// faction array
        /// </summary>
        /// <value>faction array</value>
        [JsonProperty("faction")]
        public List<int> Faction { get; set; }

        /// <summary>
        /// inventory_type array
        /// </summary>
        /// <value>inventory_type array</value>
        [JsonProperty("inventory_type")]
        public List<int> InventoryType { get; set; }

        /// <summary>
        /// region array
        /// </summary>
        /// <value>region array</value>
        [JsonProperty("region")]
        public List<int> Region { get; set; }

        /// <summary>
        /// solar_system array
        /// </summary>
        /// <value>solar_system array</value>
        [JsonProperty("solar_system")]
        public List<int> SolarSystem { get; set; }

        /// <summary>
        /// station array
        /// </summary>
        /// <value>station array</value>
        [JsonProperty("station")]
        public List<int> Station { get; set; }

        #endregion Properties
    }
}
