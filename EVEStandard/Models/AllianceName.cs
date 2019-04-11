using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AllianceName : ModelBase<AllianceName>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("alliance_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("alliance_name")]
        public string Name { get; set; }

        #endregion Properties
    }
}