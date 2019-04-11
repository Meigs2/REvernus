using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Asset : ModelBase<Asset>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the is blueprint copy.
        /// </summary>
        /// <value>
        /// The is blueprint copy.
        /// </value>
        [JsonProperty("is_blueprint_copy")]
        public bool? IsBlueprintCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is singleton.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is singleton; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_singleton")]
        public bool IsSingleton { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// Gets or sets the location flag.
        /// </summary>
        /// <value>
        /// The location flag.
        /// </value>
        [JsonProperty("location_flag")]
        public LocationFlag LocationFlag { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }
        /// <summary>
        /// Gets or sets the type of the location.
        /// </summary>
        /// <value>
        /// The type of the location.
        /// </value>
        [JsonProperty("location_type")]
        public LocationTypeEnum LocationType { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}