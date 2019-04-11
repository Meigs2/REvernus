using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class SystemJumps : ModelBase<SystemJumps>
    {
        #region Properties

        /// <summary>
        /// ship_jumps integer
        /// </summary>
        /// <value>ship_jumps integer</value>
        [JsonProperty("ship_jumps")]
        public int ShipJumps { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
