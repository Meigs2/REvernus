using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class FleetInvitation
    {
        #region Properties

        /// <summary>
        /// The character you want to invite
        /// </summary>
        /// <value>The character you want to invite</value>
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// If a character is invited with the &#x60;fleet_commander&#x60; role, neither &#x60;wing_id&#x60; or &#x60;squad_id&#x60; should be specified. If a character is invited with the &#x60;wing_commander&#x60; role, only &#x60;wing_id&#x60; should be specified. If a character is invited with the &#x60;squad_commander&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified. If a character is invited with the &#x60;squad_member&#x60; role, &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should either both be specified or not specified at all. If they aren’t specified, the invited character will join any squad with available positions.
        /// </summary>
        /// <value>If a character is invited with the &#x60;fleet_commander&#x60; role, neither &#x60;wing_id&#x60; or &#x60;squad_id&#x60; should be specified. If a character is invited with the &#x60;wing_commander&#x60; role, only &#x60;wing_id&#x60; should be specified. If a character is invited with the &#x60;squad_commander&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified. If a character is invited with the &#x60;squad_member&#x60; role, &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should either both be specified or not specified at all. If they aren’t specified, the invited character will join any squad with available positions.</value>
        [JsonProperty("role")]
        public FleetRole Role { get; set; }

        /// <summary>
        /// squad_id integer
        /// </summary>
        /// <value>squad_id integer</value>
        [JsonProperty("squad_id")]
        public long? SquadId { get; set; }

        /// <summary>
        /// wing_id integer
        /// </summary>
        /// <value>wing_id integer</value>
        [JsonProperty("wing_id")]
        public long? WingId { get; set; }

        #endregion Properties
    }
}
