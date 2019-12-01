using Newtonsoft.Json;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class OpportunitiesGroup : ModelBase<OpportunitiesGroup>
    {
        #region Properties

        /// <summary>
        /// The groups that are connected to this group on the opportunities map
        /// </summary>
        /// <value>The groups that are connected to this group on the opportunities map</value>
        [JsonProperty("connected_groups")]
        public List<int> ConnectedGroups { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// group_id integer
        /// </summary>
        /// <value>group_id integer</value>
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// notification string
        /// </summary>
        /// <value>notification string</value>
        [JsonProperty("notification")]
        public string Notification { get; set; }

        /// <summary>
        /// Tasks need to complete for this group
        /// </summary>
        /// <value>Tasks need to complete for this group</value>
        [JsonProperty("required_tasks")]
        public List<int> RequiredTasks { get; set; }

        #endregion Properties
    }
}
