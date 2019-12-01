using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class Clones : ModelBase<Clones>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets HomeLocation
        /// </summary>
        [JsonProperty("home_location")]
        public Location HomeLocation { get; set; }

        /// <summary>
        /// jump_clones array
        /// </summary>
        /// <value>jump_clones array</value>
        [JsonProperty("jump_clones")]
        public List<JumpClone> JumpClones { get; set; }

        /// <summary>
        /// last_clone_jump_date string
        /// </summary>
        /// <value>last_clone_jump_date string</value>
        [JsonProperty("last_clone_jump_date")]
        public DateTime? LastCloneJumpDate { get; set; }
        /// <summary>
        /// last_station_change_date string
        /// </summary>
        /// <value>last_station_change_date string</value>
        [JsonProperty("last_station_change_date")]
        public DateTime? LastStationChangeDate { get; set; }

        #endregion Properties
    }
}
