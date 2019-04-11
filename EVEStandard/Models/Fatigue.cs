using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Fatigue : ModelBase<Fatigue>
    {
        #region Properties

        /// <summary>
        /// Character&#39;s jump fatigue expiry
        /// </summary>
        /// <value>Character&#39;s jump fatigue expiry</value>
        [JsonProperty("jump_fatigue_expire_date")]
        public DateTime? JumpFatigueExpireDate { get; set; }

        /// <summary>
        /// Character&#39;s last jump activation
        /// </summary>
        /// <value>Character&#39;s last jump activation</value>
        [JsonProperty("last_jump_date")]
        public DateTime? LastJumpDate { get; set; }
        /// <summary>
        /// Character&#39;s last jump update
        /// </summary>
        /// <value>Character&#39;s last jump update</value>
        [JsonProperty("last_update_date")]
        public DateTime? LastUpdateDate { get; set; }

        #endregion Properties
    }
}
