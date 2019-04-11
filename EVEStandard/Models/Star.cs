using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Star : ModelBase<Star>
    {
        #region Properties

        /// <summary>
        /// Age of star in years
        /// </summary>
        /// <value>Age of star in years</value>
        [JsonProperty("age")]
        public long Age { get; set; }

        /// <summary>
        /// luminosity number
        /// </summary>
        /// <value>luminosity number</value>
        [JsonProperty("luminosity")]
        public float Luminosity { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// radius integer
        /// </summary>
        /// <value>radius integer</value>
        [JsonProperty("radius")]
        public long Radius { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonProperty("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        [JsonProperty("spectral_class")]
        public string SpectralClass { get; set; }

        /// <summary>
        /// spectral_class string
        /// </summary>
        /// <value>spectral_class string</value>
        /// <summary>
        /// temperature integer
        /// </summary>
        /// <value>temperature integer</value>
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
