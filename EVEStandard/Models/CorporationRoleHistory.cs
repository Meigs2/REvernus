using System;
using System.Collections.Generic;
using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationRoleHistory : ModelBase<CorporationRoleHistory>
    {
        #region Properties

        /// <summary>
        /// changed_at string
        /// </summary>
        /// <value>changed_at string</value>
        [JsonProperty("changed_at")]
        public DateTime ChangedAt { get; set; }

        /// <summary>
        /// The character whose roles are changed
        /// </summary>
        /// <value>The character whose roles are changed</value>
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }
        /// <summary>
        /// ID of the character who issued this change
        /// </summary>
        /// <value>ID of the character who issued this change</value>
        [JsonProperty("issuer_id")]
        public int IssuerId { get; set; }

        /// <summary>
        /// new_roles array
        /// </summary>
        /// <value>new_roles array</value>
        [JsonProperty("new_roles")]
        public List<string> NewRoles { get; set; }

        /// <summary>
        /// old_roles array
        /// </summary>
        /// <value>old_roles array</value>
        [JsonProperty("old_roles")]
        public List<string> OldRoles { get; set; }

        /// <summary>
        /// role_type string
        /// </summary>
        /// <value>role_type string</value>
        [JsonProperty("role_type")]
        public RoleTypeEnum RoleType { get; set; }

        #endregion Properties
    }
}
