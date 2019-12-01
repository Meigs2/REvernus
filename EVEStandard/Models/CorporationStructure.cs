using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class CorporationStructure : ModelBase<CorporationStructure>
    {
        #region Enums

        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        public enum StateEnum
        {
            anchor_vulnerable = 1,
            anchoring = 2,
            armor_reinforce = 3,
            armor_vulnerable = 4,
            fitting_invulnerable = 5,
            hull_reinforce = 6,
            hull_vulnerable = 7,
            online_deprecated = 8,
            onlining_vulnerable = 9,
            shield_vulnerable = 10,
            unanchored = 11,
            unknown = 12
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// ID of the corporation that owns the structure
        /// </summary>
        /// <value>ID of the corporation that owns the structure</value>
        [JsonProperty("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        /// Date on which the structure will run out of fuel
        /// </summary>
        /// <value>Date on which the structure will run out of fuel</value>
        [JsonProperty("fuel_expires")]
        public DateTime? FuelExpires { get; set; }

        /// <summary>
        /// The date and time when the structure&#39;s newly requested reinforcement times (e.g. next_reinforce_hour and next_reinforce_day) will take effect.
        /// </summary>
        /// <value>The date and time when the structure&#39;s newly requested reinforcement times (e.g. next_reinforce_hour and next_reinforce_day) will take effect.</value>
        [JsonProperty("next_reinforce_apply")]
        public DateTime? NextReinforceApply { get; set; }

        /// <summary>
        /// The requested change to reinforce_hour that will take effect at the time shown by next_reinforce_apply.
        /// </summary>
        /// <value>The requested change to reinforce_hour that will take effect at the time shown by next_reinforce_apply.</value>
        [JsonProperty("next_reinforce_hour")]
        public int? NextReinforceHour { get; set; }

        /// <summary>
        /// The requested change to reinforce_weekday that will take effect at the time shown by next_reinforce_apply.
        /// </summary>
        /// <value>The requested change to reinforce_weekday that will take effect at the time shown by next_reinforce_apply.</value>
        [JsonProperty("next_reinforce_weekday")]
        public int? NextReinforceWeekday { get; set; }

        /// <summary>
        /// The id of the ACL profile for this citadel
        /// </summary>
        /// <value>The id of the ACL profile for this citadel</value>
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        /// <summary>
        /// The hour of day that determines the four hour window when the structure will randomly exit its reinforcement periods and become vulnerable to attack against its armor and/or hull. The structure will become vulnerable at a random time that is +/- 2 hours centered on the value of this property.
        /// </summary>
        /// <value>The hour of day that determines the four hour window when the structure will randomly exit its reinforcement periods and become vulnerable to attack against its armor and/or hull. The structure will become vulnerable at a random time that is +/- 2 hours centered on the value of this property.</value>
        [JsonProperty("reinforce_hour")]
        public int ReinforceHour { get; set; }

        /// <summary>
        /// The day of the week when the structure exits its final reinforcement period and becomes vulnerable to attack against its hull. Monday is 0 and Sunday is 6.
        /// </summary>
        /// <value>The day of the week when the structure exits its final reinforcement period and becomes vulnerable to attack against its hull. Monday is 0 and Sunday is 6.</value>
        [JsonProperty("reinforce_weekday")]
        public int ReinforceWeekday { get; set; }

        /// <summary>
        /// Contains a list of service upgrades, and their state
        /// </summary>
        /// <value>Contains a list of service upgrades, and their state</value>
        [JsonProperty("services")]
        public List<StructureService> Services { get; set; }

        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        [JsonProperty("state")]
        public StateEnum State { get; set; }

        /// <summary>
        /// Date at which the structure will move to it&#39;s next state
        /// </summary>
        /// <value>Date at which the structure will move to it&#39;s next state</value>
        [JsonProperty("state_timer_end")]
        public DateTime? StateTimerEnd { get; set; }

        /// <summary>
        /// Date at which the structure entered it&#39;s current state
        /// </summary>
        /// <value>Date at which the structure entered it&#39;s current state</value>
        [JsonProperty("state_timer_start")]
        public DateTime? StateTimerStart { get; set; }

        /// <summary>
        /// The Item ID of the structure
        /// </summary>
        /// <value>The Item ID of the structure</value>
        [JsonProperty("structure_id")]
        public long StructureId { get; set; }

        /// <summary>
        /// The solar system the structure is in
        /// </summary>
        /// <value>The solar system the structure is in</value>
        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// The type id of the structure
        /// </summary>
        /// <value>The type id of the structure</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }
        /// <summary>
        /// Date at which the structure will unanchor
        /// </summary>
        /// <value>Date at which the structure will unanchor</value>
        [JsonProperty("unanchors_at")]
        public DateTime? UnanchorsAt { get; set; }

        #endregion Properties
    }

    public class StructureService : ModelBase<StructureService>
    {
        #region Enums

        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        public enum StateEnum
        {
            online = 1,
            offline = 2,
            cleanup = 3
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        [JsonProperty("state")]
        public StateEnum State { get; set; }

        #endregion Properties
    }
}
