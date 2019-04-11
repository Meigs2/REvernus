using System.Collections.Generic;
using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Station : ModelBase<Station>
    {
        #region Properties

        /// <summary>
        /// max_dockable_ship_volume number
        /// </summary>
        /// <value>max_dockable_ship_volume number</value>
        [JsonProperty("max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// office_rental_cost number
        /// </summary>
        /// <value>office_rental_cost number</value>
        [JsonProperty("office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        /// <summary>
        /// ID of the corporation that controls this station
        /// </summary>
        /// <value>ID of the corporation that controls this station</value>
        [JsonProperty("owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonProperty("race_id")]
        public int? RaceId { get; set; }

        /// <summary>
        /// reprocessing_efficiency number
        /// </summary>
        /// <value>reprocessing_efficiency number</value>
        [JsonProperty("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        /// <summary>
        /// reprocessing_stations_take number
        /// </summary>
        /// <value>reprocessing_stations_take number</value>
        [JsonProperty("reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        /// <summary>
        /// services array
        /// </summary>
        /// <value>services array</value>
        [JsonProperty("services")]
        public List<ServicesEnum> Services { get; set; }

        /// <summary>
        /// station_id integer
        /// </summary>
        /// <value>station_id integer</value>
        [JsonProperty("station_id")]
        public int StationId { get; set; }
        /// <summary>
        /// The solar system this station is in
        /// </summary>
        /// <value>The solar system this station is in</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
