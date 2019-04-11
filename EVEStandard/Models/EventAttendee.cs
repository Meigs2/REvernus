using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class EventAttendee : ModelBase<EventAttendee>
    {
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        [JsonProperty("character_id")]
        public long CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the event response.
        /// </summary>
        /// <value>
        /// The event response.
        /// </value>
        [JsonProperty("event_response")]
        public EventResponse EventResponse { get; set; }
    }
}