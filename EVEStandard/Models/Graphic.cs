using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Graphic : ModelBase<Graphic>
    {
        #region Properties

        /// <summary>
        /// collision_file string
        /// </summary>
        /// <value>collision_file string</value>
        [JsonProperty("collision_file")]
        public string CollisionFile { get; set; }

        /// <summary>
        /// graphic_file string
        /// </summary>
        /// <value>graphic_file string</value>
        [JsonProperty("graphic_file")]
        public string GraphicFile { get; set; }

        /// <summary>
        /// graphic_id integer
        /// </summary>
        /// <value>graphic_id integer</value>
        [JsonProperty("graphic_id")]
        public int GraphicId { get; set; }
        /// <summary>
        /// icon_folder string
        /// </summary>
        /// <value>icon_folder string</value>
        [JsonProperty("icon_folder")]
        public string IconFolder { get; set; }

        /// <summary>
        /// sof_dna string
        /// </summary>
        /// <value>sof_dna string</value>
        [JsonProperty("sof_dna")]
        public string SofDna { get; set; }

        /// <summary>
        /// sof_fation_name string
        /// </summary>
        /// <value>sof_fation_name string</value>
        [JsonProperty("sof_fation_name")]
        public string SofFationName { get; set; }

        /// <summary>
        /// sof_hull_name string
        /// </summary>
        /// <value>sof_hull_name string</value>
        [JsonProperty("sof_hull_name")]
        public string SofHullName { get; set; }

        /// <summary>
        /// sof_race_name string
        /// </summary>
        /// <value>sof_race_name string</value>
        [JsonProperty("sof_race_name")]
        public string SofRaceName { get; set; }

        #endregion Properties
    }
}
