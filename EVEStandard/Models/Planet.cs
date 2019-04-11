using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Planet : ModelBase<Planet>
    {
        #region Properties

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// planet_id integer
        /// </summary>
        /// <value>planet_id integer</value>
        [JsonProperty("planet_id")]
        public int PlanetId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The solar system this planet is in
        /// </summary>
        /// <value>The solar system this planet is in</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
