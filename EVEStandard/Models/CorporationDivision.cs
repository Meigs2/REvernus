using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class CorporationDivision : ModelBase<CorporationDivision>
    {
        #region Properties

        /// <summary>
        /// hangar array
        /// </summary>
        /// <value>hangar array</value>
        [JsonProperty("hangar")]
        public List<DivisionHanger> Hangar { get; set; }

        /// <summary>
        /// wallet array
        /// </summary>
        /// <value>wallet array</value>
        [JsonProperty("wallet")]
        public List<DivisionWallet> Wallet { get; set; }

        #endregion Properties
    }

    public class DivisionHanger : ModelBase<DivisionHanger>
    {
        #region Properties

        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonProperty("division")]
        public int? Division { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion Properties
    }

    public class DivisionWallet : ModelBase<DivisionWallet>
    {
        #region Properties

        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonProperty("division")]
        public int? Division { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
