using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Ancestry : ModelBase<Ancestry>
    {
        #region Properties

        /// <summary>
        /// The bloodline associated with this ancestry
        /// </summary>
        /// <value>The bloodline associated with this ancestry</value>
        [JsonProperty("bloodline_id")]
        public int BloodlineId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonProperty("icon_id")]
        public int? IconId { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// short_description string
        /// </summary>
        /// <value>short_description string</value>
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        #endregion Properties
    }
}
