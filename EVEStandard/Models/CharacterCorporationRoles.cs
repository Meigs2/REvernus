using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterCorporationRoles : ModelBase<CharacterCorporationRoles>
    {
        #region Properties

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
