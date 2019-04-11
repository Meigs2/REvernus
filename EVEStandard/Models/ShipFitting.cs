using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class FittingItem : ModelBase<FittingItem>
    {
        #region Properties

        /// <summary>
        /// flag integer
        /// </summary>
        /// <value>flag integer</value>
        [JsonProperty("flag")]
        public int Flag { get; set; }

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

    public class ShipFitting : ModelBase<ShipFitting>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonProperty("items")]
        public List<FittingItem> Items { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonProperty("ship_type_id")]
        public int ShipTypeId { get; set; }

        #endregion Properties
    }
}
