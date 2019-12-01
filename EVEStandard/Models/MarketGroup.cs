using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class MarketGroup : ModelBase<MarketGroup>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// market_group_id integer
        /// </summary>
        /// <value>market_group_id integer</value>
        [JsonProperty("market_group_id")]
        public int MarketGroupId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// parent_group_id integer
        /// </summary>
        /// <value>parent_group_id integer</value>
        [JsonProperty("parent_group_id")]
        public int? ParentGroupId { get; set; }

        /// <summary>
        /// types array
        /// </summary>
        /// <value>types array</value>
        [JsonProperty("types")]
        public List<int> Types { get; set; }

        #endregion Properties
    }
}
