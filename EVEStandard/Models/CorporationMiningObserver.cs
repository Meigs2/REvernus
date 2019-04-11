using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationMiningObserver : ModelBase<CorporationMiningObserver>
    {
        /// <summary>
        /// last_updated string
        /// </summary>
        /// <value>last_updated string</value>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The entity that was observing the asteroid field when it was mined. 
        /// </summary>
        /// <value>The entity that was observing the asteroid field when it was mined. </value>
        [JsonProperty("observer_id")]
        public long ObserverId { get; set; }
        /// <summary>
        /// The category of the observing entity
        /// </summary>
        /// <value>The category of the observing entity</value>
        public enum ObserverTypeEnum
        {
            structure = 1
        }

        /// <summary>
        /// The category of the observing entity
        /// </summary>
        /// <value>The category of the observing entity</value>
        [JsonProperty("observer_type")]
        public ObserverTypeEnum ObserverType { get; set; }
    }
}
