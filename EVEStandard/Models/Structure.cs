using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Structure : ModelBase<Structure>
    {
        #region Properties

        /// <summary>
        /// The full name of the structure
        /// </summary>
        /// <value>The full name of the structure</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the corporation who owns this particular structure
        /// </summary>
        /// <value>The ID of the corporation who owns this particular structure</value>
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonProperty("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        #endregion Properties
    }
}
