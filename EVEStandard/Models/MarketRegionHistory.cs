using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class MarketRegionHistory : ModelBase<MarketRegionHistory>
    {
        #region Properties

        /// <summary>
        /// average number
        /// </summary>
        /// <value>average number</value>
        [JsonProperty("average")]
        public double Average { get; set; }

        /// <summary>
        /// The date of this historical statistic entry
        /// </summary>
        /// <value>The date of this historical statistic entry</value>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// highest number
        /// </summary>
        /// <value>highest number</value>
        [JsonProperty("highest")]
        public double Highest { get; set; }

        /// <summary>
        /// lowest number
        /// </summary>
        /// <value>lowest number</value>
        [JsonProperty("lowest")]
        public double Lowest { get; set; }

        /// <summary>
        /// Total number of orders happened that day
        /// </summary>
        /// <value>Total number of orders happened that day</value>
        [JsonProperty("order_count")]
        public long OrderCount { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        /// <value>Total</value>
        [JsonProperty("volume")]
        public long Volume { get; set; }

        #endregion Properties
    }
}
