using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Standing : ModelBase<Standing>
    {
        #region Enums

        /// <summary>
        /// from_type string
        /// </summary>
        /// <value>from_type string</value>
        public enum FromTypeEnum
        {
            agent = 1,
            npc_corp = 2,
            faction = 3
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// from_id integer
        /// </summary>
        /// <value>from_id integer</value>
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        /// <summary>
        /// from_type string
        /// </summary>
        /// <value>from_type string</value>
        [JsonProperty("from_type")]
        public FromTypeEnum FromType { get; set; }

        /// <summary>
        /// standing number
        /// </summary>
        /// <value>standing number</value>
        [JsonProperty("standing")]
        public float StandingValue { get; set; }

        #endregion Properties
    }
}
