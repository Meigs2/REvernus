using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class OutpostDetail : ModelBase<OutpostDetail>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets Coordinates
        /// </summary>
        [JsonProperty("coordinates")]
        public Position Coordinates { get; set; }

        /// <summary>
        /// docking_cost_per_ship_volume number
        /// </summary>
        /// <value>docking_cost_per_ship_volume number</value>
        [JsonProperty("docking_cost_per_ship_volume")]
        public float DockingCostPerShipVolume { get; set; }

        /// <summary>
        /// office_rental_cost integer
        /// </summary>
        /// <value>office_rental_cost integer</value>
        [JsonProperty("office_rental_cost")]
        public long OfficeRentalCost { get; set; }

        /// <summary>
        /// The entity that owns the station (e.g. the entity whose logo is on the station services bar)
        /// </summary>
        /// <value>The entity that owns the station (e.g. the entity whose logo is on the station services bar)</value>
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// reprocessing_efficiency number
        /// </summary>
        /// <value>reprocessing_efficiency number</value>
        [JsonProperty("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        /// <summary>
        /// reprocessing_station_take number
        /// </summary>
        /// <value>reprocessing_station_take number</value>
        [JsonProperty("reprocessing_station_take")]
        public float ReprocessingStationTake { get; set; }

        /// <summary>
        /// A list of services the given outpost provides
        /// </summary>
        /// <value>A list of services the given outpost provides</value>
        [JsonProperty("services")]
        public List<OutpostService> Services { get; set; }

        /// <summary>
        /// The owner ID that sets the ability for someone to dock based on standings.
        /// </summary>
        /// <value>The owner ID that sets the ability for someone to dock based on standings.</value>
        [JsonProperty("standing_owner_id")]
        public int StandingOwnerId { get; set; }

        /// <summary>
        /// The ID of the solar system the outpost rests in
        /// </summary>
        /// <value>The ID of the solar system the outpost rests in</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }
        /// <summary>
        /// The type ID of the given outpost
        /// </summary>
        /// <value>The type ID of the given outpost</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }

    public class OutpostService : ModelBase<OutpostService>
    {
        #region Properties

        /// <summary>
        /// discount_per_good_standing number
        /// </summary>
        /// <value>discount_per_good_standing number</value>
        [JsonProperty("discount_per_good_standing")]
        public double DiscountPerGoodStanding { get; set; }

        /// <summary>
        /// minimum_standing number
        /// </summary>
        /// <value>minimum_standing number</value>
        [JsonProperty("minimum_standing")]
        public double MinimumStanding { get; set; }

        /// <summary>
        /// service_name string
        /// </summary>
        /// <value>service_name string</value>
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }
        /// <summary>
        /// surcharge_per_bad_standing number
        /// </summary>
        /// <value>surcharge_per_bad_standing number</value>
        [JsonProperty("surcharge_per_bad_standing")]
        public double SurchargePerBadStanding { get; set; }

        #endregion Properties
    }
}
