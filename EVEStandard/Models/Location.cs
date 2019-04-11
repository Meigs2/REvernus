using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Location : ModelBase<Location>
    {
        #region Properties

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// location_type string
        /// </summary>
        /// <value>location_type string</value>
        [JsonProperty("location_type")]
        public LocationType? LocationType { get; set; }

        #endregion Properties
    }
}
