using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class UniverseIdsToNames : ModelBase<UniverseIdsToNames>
    {
        #region Properties

        /// <summary>
        /// category string
        /// </summary>
        /// <value>category string</value>
        [JsonProperty("category")]
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
