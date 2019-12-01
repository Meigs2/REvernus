using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class Bookmark : ModelBase<Bookmark>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the bookmark identifier.
        /// </summary>
        /// <value>
        /// The bookmark identifier.
        /// </value>
        [JsonProperty("bookmark_id")]
        public long BookmarkId { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>
        /// The coordinates.
        /// </value>
        [JsonProperty("coordinates")]
        public Position Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>
        /// The creator identifier.
        /// </value>
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        /// <value>
        /// The folder identifier.
        /// </value>
        [JsonProperty("folder_id")]
        public long? FolderId { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        [JsonProperty("item")]
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        #endregion Properties
    }
}