using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVEStandard.Models
{
    public class Event : ModelBase<Event>
    {
        #region Enums

        public enum OwnerTypeEnum
        {
            eve_server,
            corporation,
            faction,
            character,
            alliance
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        [JsonProperty("event_id")]
        public long EventId { get; set; }

        /// <summary>
        /// Gets or sets the importance.
        /// </summary>
        /// <value>
        /// The importance.
        /// </value>
        [JsonProperty("importance")]
        public int Importance { get; set; }

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the type of the owner.
        /// </summary>
        /// <value>
        /// The type of the owner.
        /// </value>
        [JsonProperty("owner_type")]
        public OwnerTypeEnum OwnerType { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [JsonProperty("response")]
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion Properties
    }
}