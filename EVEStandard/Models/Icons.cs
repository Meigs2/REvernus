using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Icons : ModelBase<Icons>
    {
        #region Properties

        /// <summary>
        ///     px64x64 string
        /// </summary>
        /// <value>px64x64 string</value>
        [JsonProperty("px64x64")]
        public string Px64x64 { get; set; }

        /// <summary>
        ///     px128x128 string
        /// </summary>
        /// <value>px128x128 string</value>
        [JsonProperty("px128x128")]
        public string Px128x128 { get; set; }

        /// <summary>
        ///     px256x256 string
        /// </summary>
        /// <value>px256x256 string</value>
        [JsonProperty("px256x256")]
        public string Px256x256 { get; set; }

        /// <summary>
        ///     px512x512 string
        /// </summary>
        /// <value>px512x512 string</value>
        [JsonProperty("px512x512")]
        public string Px512x512 { get; set; }

        #endregion
    }
}