using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Calendar API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Calendar : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Calendar>();

        internal Calendar(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Get 50 event summaries from the calendar. 
        /// If no from_event ID is given, the resource will return the next 50 chronological event summaries from now. 
        /// If a from_event ID is specified, it will return the next 50 chronological event summaries from after that event.
        /// <para>GET /characters/{character_id}/calendar/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fromEventId">The event ID to retrieve events from.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a collection of event summaries.</returns>
        public async Task<ESIModelDTO<List<EventSummary>>> ListCalendarEventSummariesV1Async(AuthDTO auth, long? fromEventId = null, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            Dictionary<string, string> queryParameters = null;
            if (fromEventId != null)
            {
                queryParameters = new Dictionary<string, string>
                {
                    { "from_event", fromEventId.ToString() }
                };
            }

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/calendar/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCalendarEventSummariesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<EventSummary>>(responseModel);
        }

        /// <summary>
        /// Get all the information for a specific event.
        /// <para>GET /characters/{character_id}/calendar/{event_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing full details of a specific event.</returns>
        public async Task<ESIModelDTO<Event>> GetAnEventV3Async(AuthDTO auth, long eventId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/calendar/" + eventId + "/", auth, ifNoneMatch);

            CheckResponse(nameof(GetAnEventV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Event>(responseModel);
        }

        /// <summary>
        /// Set your response status to an event.
        /// <para>PUT /characters/{character_id}/calendar/{event_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="response">The response value to set, overriding current value.</param>
        /// <returns></returns>
        public async Task RespondToAnEventV3Async(AuthDTO auth, long eventId, EventResponse response)
        {
            CheckAuth(auth, Scopes.ESI_CALENDAR_RESPOND_CALENDAR_EVENTS_1);

            dynamic body = new JObject();
            body.response = response.ToString();

            var responseModel = await this.PutAsync($"/v3/characters/{auth.CharacterId}/calendar/" + eventId + "/", auth, body);

            CheckResponse(nameof(RespondToAnEventV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Get all invited attendees for a given event.
        /// <para>GET /characters/{character_id}/calendar/{event_id}/attendees/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="eventId">The id of the event requested.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of attendees.</returns>
        public async Task<ESIModelDTO<List<EventAttendee>>> GetAttendeesV1Async(AuthDTO auth, long eventId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/calendar/" + eventId + "/attendees/", auth, ifNoneMatch);

            CheckResponse(nameof(GetAttendeesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<EventAttendee>>(responseModel);
        }
    }
}
