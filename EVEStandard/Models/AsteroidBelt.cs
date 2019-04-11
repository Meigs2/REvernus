using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AsteroidBelt : ModelBase<AsteroidBelt>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the system identifier.
        /// </summary>
        /// <value>
        /// The system identifier.
        /// </value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
