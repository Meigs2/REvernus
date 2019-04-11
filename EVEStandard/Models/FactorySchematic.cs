using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class FactorySchematic : ModelBase<FactorySchematic>
    {
        #region Properties

        /// <summary>
        /// Time in seconds to process a run
        /// </summary>
        /// <value>Time in seconds to process a run</value>
        [JsonProperty("cycle_time")]
        public int CycleTime { get; set; }

        /// <summary>
        /// schematic_name string
        /// </summary>
        /// <value>schematic_name string</value>
        [JsonProperty("schematic_name")]
        public string SchematicName { get; set; }

        #endregion Properties
    }
}
