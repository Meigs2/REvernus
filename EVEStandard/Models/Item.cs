using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Item : ModelBase<Item>
    {
        #region Properties

        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
