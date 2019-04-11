using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class StarbaseDetail : ModelBase<StarbaseDetail>
    {
        #region Enums

        /// <summary>
        /// Who can view the starbase (POS)'s fule bay. Characters either need to have required role or belong to the starbase (POS) owner's corporation or alliance, as described by the enum, all other access settings follows the same scheme
        /// </summary>
        /// <value>Who can view the starbase (POS)'s fule bay. Characters either need to have required role or belong to the starbase (POS) owner's corporation or alliance, as described by the enum, all other access settings follows the same scheme</value>
        public enum PermissionEnum
        {
            alliance_member = 1,
            config_starbase_equipment_role = 2,
            corporation_member = 3,
            starbase_fuel_technician_role = 4
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// allow_alliance_members boolean
        /// </summary>
        /// <value>allow_alliance_members boolean</value>
        [JsonProperty("allow_alliance_members")]
        public bool AllowAllianceMembers { get; set; }

        /// <summary>
        /// allow_corporation_members boolean
        /// </summary>
        /// <value>allow_corporation_members boolean</value>
        [JsonProperty("allow_corporation_members")]
        public bool AllowCorporationMembers { get; set; }

        /// <summary>
        /// Who can anchor starbase (POS) and its structures
        /// </summary>
        /// <value>Who can anchor starbase (POS) and its structures</value>
        [JsonProperty("anchor")]
        public PermissionEnum Anchor { get; set; }

        /// <summary>
        /// attack_if_at_war boolean
        /// </summary>
        /// <value>attack_if_at_war boolean</value>
        [JsonProperty("attack_if_at_war")]
        public bool AttackIfAtWar { get; set; }

        /// <summary>
        /// attack_if_other_security_status_dropping boolean
        /// </summary>
        /// <value>attack_if_other_security_status_dropping boolean</value>
        [JsonProperty("attack_if_other_security_status_dropping")]
        public bool? AttackIfOtherSecurityStatusDropping { get; set; }

        /// <summary>
        /// Starbase (POS) will attack if target&#39;s security standing is lower than this value
        /// </summary>
        /// <value>Starbase (POS) will attack if target&#39;s security standing is lower than this value</value>
        [JsonProperty("attack_security_status_threshold")]
        public float? AttackSecurityStatusThreshold { get; set; }

        /// <summary>
        /// Starbase (POS) will attack if target&#39;s standing is lower than this value
        /// </summary>
        /// <value>Starbase (POS) will attack if target&#39;s standing is lower than this value</value>
        [JsonProperty("attack_standing_threshold")]
        public float? AttackStandingThreshold { get; set; }

        /// <summary>
        /// Who can take fuel blocks out of the starbase (POS)&#39;s fuel bay
        /// </summary>
        /// <value>Who can take fuel blocks out of the starbase (POS)&#39;s fuel bay</value>
        [JsonProperty("fuel_bay_take")]
        public PermissionEnum FuelBayTake { get; set; }

        /// <summary>
        /// Who can view the starbase (POS)&#39;s fule bay. Characters either need to have required role or belong to the starbase (POS) owner&#39;s corporation or alliance, as described by the enum, all other access settings follows the same scheme
        /// </summary>
        /// <value>Who can view the starbase (POS)&#39;s fule bay. Characters either need to have required role or belong to the starbase (POS) owner&#39;s corporation or alliance, as described by the enum, all other access settings follows the same scheme</value>
        [JsonProperty("fuel_bay_view")]
        public PermissionEnum FuelBayView { get; set; }
        /// <summary>
        /// Fuel blocks and other things that will be consumed when operating a starbase (POS)
        /// </summary>
        /// <value>Fuel blocks and other things that will be consumed when operating a starbase (POS)</value>
        [JsonProperty("fuels")]
        public List<StarbaseFuel> Fuels { get; set; }

        /// <summary>
        /// Who can offline starbase (POS) and its structures
        /// </summary>
        /// <value>Who can offline starbase (POS) and its structures</value>
        [JsonProperty("offline")]
        public PermissionEnum Offline { get; set; }

        /// <summary>
        /// Who can online starbase (POS) and its structures
        /// </summary>
        /// <value>Who can online starbase (POS) and its structures</value>
        [JsonProperty("online")]
        public PermissionEnum Online { get; set; }

        /// <summary>
        /// Who can unanchor starbase (POS) and its structures
        /// </summary>
        /// <value>Who can unanchor starbase (POS) and its structures</value>
        [JsonProperty("unanchor")]
        public PermissionEnum Unanchor { get; set; }
        /// <summary>
        /// True if the starbase (POS) is using alliance standings, otherwise using corporation&#39;s
        /// </summary>
        /// <value>True if the starbase (POS) is using alliance standings, otherwise using corporation&#39;s</value>
        [JsonProperty("use_alliance_standings")]
        public bool UseAllianceStandings { get; set; }

        #endregion Properties
    }

    public class StarbaseFuel : ModelBase<StarbaseFuel>
    {
        #region Properties

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        #endregion Properties
    }
}
