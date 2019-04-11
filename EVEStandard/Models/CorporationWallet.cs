using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationWallet : ModelBase<CorporationWallet>
    {
        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonProperty("division")]
        public int Division { get; set; }

        /// <summary>
        /// balance number
        /// </summary>
        /// <value>balance number</value>
        [JsonProperty("balance")]
        public double Balance { get; set; }
    }
}
