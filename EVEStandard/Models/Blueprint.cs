using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Blueprint : ModelBase<Blueprint>
    {
        #region Properties

        /// <summary>
        /// Unique ID for this item.
        /// </summary>
        /// <value>Unique ID for this item.</value>
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// Type of the location_id
        /// </summary>
        /// <value>Type of the location_id</value>
        [JsonProperty("location_flag")]
        public LocationFlag LocationFlag { get; set; }

        /// <summary>
        /// References a solar system, station or item_id if this blueprint is located within a container. If the return value is an item_id, then the Character AssetList API must be queried to find the container using the given item_id to determine the correct location of the Blueprint.
        /// </summary>
        /// <value>References a solar system, station or item_id if this blueprint is located within a container. If the return value is an item_id, then the Character AssetList API must be queried to find the container using the given item_id to determine the correct location of the Blueprint.</value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// Material Efficiency Level of the blueprint.
        /// </summary>
        /// <value>Material Efficiency Level of the blueprint.</value>
        [JsonProperty("material_efficiency")]
        public int MaterialEfficiency { get; set; }

        /// <summary>
        /// A range of numbers with a minimum of -2 and no maximum value where -1 is an original and -2 is a copy. It can be a positive integer if it is a stack of blueprint originals fresh from the market (e.g. no activities performed on them yet).
        /// </summary>
        /// <value>A range of numbers with a minimum of -2 and no maximum value where -1 is an original and -2 is a copy. It can be a positive integer if it is a stack of blueprint originals fresh from the market (e.g. no activities performed on them yet).</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Number of runs remaining if the blueprint is a copy, -1 if it is an original.
        /// </summary>
        /// <value>Number of runs remaining if the blueprint is a copy, -1 if it is an original.</value>
        [JsonProperty("runs")]
        public int Runs { get; set; }

        /// <summary>
        /// Time Efficiency Level of the blueprint.
        /// </summary>
        /// <value>Time Efficiency Level of the blueprint.</value>
        [JsonProperty("time_efficiency")]
        public int TimeEfficiency { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
