using EVEStandard.Enumerations;
using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class EventSummary : ModelBase<EventSummary>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        [JsonProperty("event_id")]
        public long EventId { get; set; }

        /// <summary>
        /// Gets or sets the event response.
        /// </summary>
        /// <value>
        /// The event response.
        /// </value>
        [JsonProperty("event_response")]
        public EventResponse EventResponse { get; set; }

        /// <summary>
        /// Gets or sets the importance.
        /// </summary>
        /// <value>
        /// The importance.
        /// </value>
        [JsonProperty("importance")]
        public int Importance { get; set; }

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