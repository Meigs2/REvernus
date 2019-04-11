using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AllianceIcons : ModelBase<AllianceIcons>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the PX128X128.
        /// </summary>
        /// <value>
        /// The PX128X128.
        /// </value>
        [JsonProperty("px128x128")]
        public string Px128x128 { get; set; }

        /// <summary>
        /// Gets or sets the PX64X64.
        /// </summary>
        /// <value>
        /// The PX64X64.
        /// </value>
        [JsonProperty("px64x64")]
        public string Px64x64 { get; set; }

        #endregion Properties
    }
}