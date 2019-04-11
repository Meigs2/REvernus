using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterSkills : ModelBase<CharacterSkills>
    {
        #region Properties

        /// <summary>
        /// skills array
        /// </summary>
        /// <value>skills array</value>
        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// total_sp integer
        /// </summary>
        /// <value>total_sp integer</value>
        [JsonProperty("total_sp")]
        public long TotalSp { get; set; }

        /// <summary>
        /// Skill points available to be assigned
        /// </summary>
        /// <value>Skill points available to be assigned</value>
        [JsonProperty("unallocated_sp")]
        public int? UnallocatedSp { get; set; }

        #endregion Properties
    }

    public class Skill : ModelBase<Skill>
    {
        #region Properties

        /// <summary>
        /// active_skill_level integer
        /// </summary>
        /// <value>active_skill_level integer</value>
        [JsonProperty("active_skill_level")]
        public int ActiveSkillLevel { get; set; }

        /// <summary>
        /// skill_id integer
        /// </summary>
        /// <value>skill_id integer</value>
        [JsonProperty("skill_id")]
        public int SkillId { get; set; }

        /// <summary>
        /// skillpoints_in_skill integer
        /// </summary>
        /// <value>skillpoints_in_skill integer</value>
        [JsonProperty("skillpoints_in_skill")]
        public long SkillpointsInSkill { get; set; }

        /// <summary>
        /// trained_skill_level integer
        /// </summary>
        /// <value>trained_skill_level integer</value>
        [JsonProperty("trained_skill_level")]
        public int TrainedSkillLevel { get; set; }

        #endregion Properties
    }
}
