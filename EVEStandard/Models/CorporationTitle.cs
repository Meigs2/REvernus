using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class CorporationTitle : ModelBase<CorporationTitle>
    {
        #region Properties

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
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

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

        /// <summary>
        /// title_id integer
        /// </summary>
        /// <value>title_id integer</value>
        [JsonProperty("title_id")]
        public int TitleId { get; set; }

        #endregion Properties
    }
}
