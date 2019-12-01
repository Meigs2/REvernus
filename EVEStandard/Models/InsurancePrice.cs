using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class InsurancePrice : ModelBase<InsurancePrice>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// A list of a available insurance levels for this ship type
        /// </summary>
        /// <value>A list of a available insurance levels for this ship type</value>
        [JsonProperty("levels")]
        public List<InsurancePricesLevel> Levels { get; set; }
    }

    public class InsurancePricesLevel : ModelBase<InsurancePricesLevel>
    {
        /// <summary>
        /// cost number
        /// </summary>
        /// <value>cost number</value>
        [JsonProperty("cost")]
        public float Cost { get; set; }

        /// <summary>
        /// payout number
        /// </summary>
        /// <value>payout number</value>
        [JsonProperty("payout")]
        public float Payout { get; set; }

        /// <summary>
        /// Localized insurance level
        /// </summary>
        /// <value>Localized insurance level</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
