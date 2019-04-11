using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class LoyaltyStoreOffer : ModelBase<LoyaltyStoreOffer>
    {
        #region Properties

        /// <summary>
        /// Analysis kredit cost
        /// </summary>
        /// <value>Analysis kredit cost</value>
        [JsonProperty("ak_cost")]
        public int? AkCost { get; set; }

        /// <summary>
        /// isk_cost integer
        /// </summary>
        /// <value>isk_cost integer</value>
        [JsonProperty("isk_cost")]
        public long IskCost { get; set; }

        /// <summary>
        /// lp_cost integer
        /// </summary>
        /// <value>lp_cost integer</value>
        [JsonProperty("lp_cost")]
        public int LpCost { get; set; }

        /// <summary>
        /// offer_id integer
        /// </summary>
        /// <value>offer_id integer</value>
        [JsonProperty("offer_id")]
        public int OfferId { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// required_items array
        /// </summary>
        /// <value>required_items array</value>
        [JsonProperty("required_items")]
        public List<LoyaltyStoreRequiredItem> RequiredItems { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }

    public class LoyaltyStoreRequiredItem : ModelBase<LoyaltyStoreRequiredItem>
    {
        #region Properties

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
