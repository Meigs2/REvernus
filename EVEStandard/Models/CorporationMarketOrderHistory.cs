using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class CorporationMarketOrderHistory : ModelBase<CorporationMarketOrderHistory>
    {
        #region Enums

        /// <summary>
        /// Current order state
        /// </summary>
        /// <value>Current order state</value>
        public enum StateEnum
        {
            cancelled = 1,
            expired = 2
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Number of days the order was valid for (starting from the issued date). An order expires at time issued + duration
        /// </summary>
        /// <value>Number of days the order was valid for (starting from the issued date). An order expires at time issued + duration</value>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// For buy orders, the amount of ISK in escrow
        /// </summary>
        /// <value>For buy orders, the amount of ISK in escrow</value>
        [JsonProperty("escrow")]
        public double? Escrow { get; set; }

        /// <summary>
        /// True if the order is a bid (buy) order
        /// </summary>
        /// <value>True if the order is a bid (buy) order</value>
        [JsonProperty("is_buy_order")]
        public bool? IsBuyOrder { get; set; }

        /// <summary>
        /// Date and time when this order was issued
        /// </summary>
        /// <value>Date and time when this order was issued</value>
        [JsonProperty("issued")]
        public DateTime Issued { get; set; }

        /// <summary>
        /// The character who issued this order 
        /// </summary>
        /// <value>The character who issued this order </value>
        [JsonProperty("issued_by")]
        public int IssuedBy { get; set; }

        /// <summary>
        /// ID of the location where order was placed
        /// </summary>
        /// <value>ID of the location where order was placed</value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// For buy orders, the minimum quantity that will be accepted in a matching sell order
        /// </summary>
        /// <value>For buy orders, the minimum quantity that will be accepted in a matching sell order</value>
        [JsonProperty("min_volume")]
        public int? MinVolume { get; set; }

        /// <summary>
        /// Unique order ID
        /// </summary>
        /// <value>Unique order ID</value>
        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// Cost per unit for this order
        /// </summary>
        /// <value>Cost per unit for this order</value>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// Valid order range, numbers are ranges in jumps
        /// </summary>
        /// <value>Valid order range, numbers are ranges in jumps</value>
        [JsonProperty("range")]
        public string Range { get; set; }

        /// <summary>
        /// ID of the region where order was placed
        /// </summary>
        /// <value>ID of the region where order was placed</value>
        [JsonProperty("region_id")]
        public int RegionId { get; set; }

        /// <summary>
        /// Current order state
        /// </summary>
        /// <value>Current order state</value>
        [JsonProperty("state")]
        public StateEnum State { get; set; }

        /// <summary>
        /// The type ID of the item transacted in this order
        /// </summary>
        /// <value>The type ID of the item transacted in this order</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }
        /// <summary>
        /// Quantity of items still required or offered
        /// </summary>
        /// <value>Quantity of items still required or offered</value>
        [JsonProperty("volume_remain")]
        public int VolumeRemain { get; set; }

        /// <summary>
        /// Quantity of items required or offered at time order was placed
        /// </summary>
        /// <value>Quantity of items required or offered at time order was placed</value>
        [JsonProperty("volume_total")]
        public int VolumeTotal { get; set; }
        /// <summary>
        /// The corporation wallet division used for this order.
        /// </summary>
        /// <value>The corporation wallet division used for this order.</value>
        [JsonProperty("wallet_division")]
        public int WalletDivision { get; set; }

        #endregion Properties
    }
}
