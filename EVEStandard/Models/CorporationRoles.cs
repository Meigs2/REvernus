using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationRoles : ModelBase<CorporationRoles>
    {
        #region Properties

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// grantable_roles array
        /// </summary>
        /// <value>grantable_roles array</value>
        [JsonProperty("grantable_roles")]
        public List<string> GrantableRoles { get; set; }

        /// <summary>
        /// grantable_roles_at_base array
        /// </summary>
        /// <value>grantable_roles_at_base array</value>
        [JsonProperty("grantable_roles_at_base")]
        public List<string> GrantableRolesAtBase { get; set; }

        /// <summary>
        /// grantable_roles_at_hq array
        /// </summary>
        /// <value>grantable_roles_at_hq array</value>
        [JsonProperty("grantable_roles_at_hq")]
        public List<string> GrantableRolesAtHq { get; set; }

        /// <summary>
        /// grantable_roles_at_other array
        /// </summary>
        /// <value>grantable_roles_at_other array</value>
        [JsonProperty("grantable_roles_at_other")]
        public List<string> GrantableRolesAtOther { get; set; }

        /// <summary>
        /// roles array
        /// </summary>
        /// <value>roles array</value>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
        /// <summary>
        /// roles_at_base array
        /// </summary>
        /// <value>roles_at_base array</value>
        [JsonProperty("roles_at_base")]
        public List<string> RolesAtBase { get; set; }

        /// <summary>
        /// roles_at_hq array
        /// </summary>
        /// <value>roles_at_hq array</value>
        [JsonProperty("roles_at_hq")]
        public List<string> RolesAtHq { get; set; }
        /// <summary>
        /// roles_at_other array
        /// </summary>
        /// <value>roles_at_other array</value>
        [JsonProperty("roles_at_other")]
        public List<string> RolesAtOther { get; set; }

        #endregion Properties
    }
}
