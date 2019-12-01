using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class CharacterAttributes : ModelBase<CharacterAttributes>
    {
        #region Properties

        /// <summary>
        /// Neural remapping cooldown after a character uses remap accrued over time
        /// </summary>
        /// <value>Neural remapping cooldown after a character uses remap accrued over time</value>
        [JsonProperty("accrued_remap_cooldown_date")]
        public DateTime? AccruedRemapCooldownDate { get; set; }

        /// <summary>
        /// Number of available bonus character neural remaps
        /// </summary>
        /// <value>Number of available bonus character neural remaps</value>
        [JsonProperty("bonus_remaps")]
        public int? BonusRemaps { get; set; }

        /// <summary>
        /// charisma integer
        /// </summary>
        /// <value>charisma integer</value>
        [JsonProperty("charisma")]
        public int Charisma { get; set; }

        /// <summary>
        /// intelligence integer
        /// </summary>
        /// <value>intelligence integer</value>
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        /// <summary>
        /// Datetime of last neural remap, including usage of bonus remaps
        /// </summary>
        /// <value>Datetime of last neural remap, including usage of bonus remaps</value>
        [JsonProperty("last_remap_date")]
        public DateTime? LastRemapDate { get; set; }

        /// <summary>
        /// memory integer
        /// </summary>
        /// <value>memory integer</value>
        [JsonProperty("memory")]
        public int Memory { get; set; }

        /// <summary>
        /// perception integer
        /// </summary>
        /// <value>perception integer</value>
        [JsonProperty("perception")]
        public int Perception { get; set; }

        /// <summary>
        /// willpower integer
        /// </summary>
        /// <value>willpower integer</value>
        [JsonProperty("willpower")]
        public int Willpower { get; set; }

        #endregion Properties
    }
}
