using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class MarketOrder : ModelBase<MarketOrder>
    {
        #region Properties

        /// <summary>
        /// duration integer
        /// </summary>
        /// <value>duration integer</value>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// is_buy_order boolean
        /// </summary>
        /// <value>is_buy_order boolean</value>
        [JsonProperty("is_buy_order")]
        public bool IsBuyOrder { get; set; }

        /// <summary>
        /// issued string
        /// </summary>
        /// <value>issued string</value>
        [JsonProperty("issued")]
        public DateTime Issued { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// min_volume integer
        /// </summary>
        /// <value>min_volume integer</value>
        [JsonProperty("min_volume")]
        public int MinVolume { get; set; }

        /// <summary>
        /// order_id integer
        /// </summary>
        /// <value>order_id integer</value>
        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// price number
        /// </summary>
        /// <value>price number</value>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// range string
        /// </summary>
        /// <value>range string</value>
        [JsonProperty("range")]
        public string Range { get; set; }

        /// <summary>
        /// Gets or sets the system identifier.
        /// </summary>
        /// <value>
        /// The system identifier.
        /// </value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// volume_remain integer
        /// </summary>
        /// <value>volume_remain integer</value>
        [JsonProperty("volume_remain")]
        public int VolumeRemain { get; set; }

        /// <summary>
        /// volume_total integer
        /// </summary>
        /// <value>volume_total integer</value>
        [JsonProperty("volume_total")]
        public int VolumeTotal { get; set; }

        #endregion Properties
    }
}
