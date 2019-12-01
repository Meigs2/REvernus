using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class CharacterFitting : ModelBase<CharacterFitting>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// fitting_id integer
        /// </summary>
        /// <value>fitting_id integer</value>
        [JsonProperty("fitting_id")]
        public int FittingId { get; set; }

        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonProperty("items")]
        public List<CharacterFittingItem> Items { get; set; }

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

    public class CharacterFittingItem : ModelBase<CharacterFittingItem>
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
}
