using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class DogmaEffect : ModelBase<DogmaEffect>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// disallow_auto_repeat boolean
        /// </summary>
        /// <value>disallow_auto_repeat boolean</value>
        [JsonProperty("disallow_auto_repeat")]
        public bool? DisallowAutoRepeat { get; set; }

        /// <summary>
        /// discharge_attribute_id integer
        /// </summary>
        /// <value>discharge_attribute_id integer</value>
        [JsonProperty("discharge_attribute_id")]
        public int? DischargeAttributeId { get; set; }

        /// <summary>
        /// display_name string
        /// </summary>
        /// <value>display_name string</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// duration_attribute_id integer
        /// </summary>
        /// <value>duration_attribute_id integer</value>
        [JsonProperty("duration_attribute_id")]
        public int? DurationAttributeId { get; set; }

        /// <summary>
        /// effect_category integer
        /// </summary>
        /// <value>effect_category integer</value>
        [JsonProperty("effect_category")]
        public int? EffectCategory { get; set; }

        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [JsonProperty("effect_id")]
        public int EffectId { get; set; }

        /// <summary>
        /// electronic_chance boolean
        /// </summary>
        /// <value>electronic_chance boolean</value>
        [JsonProperty("electronic_chance")]
        public bool? ElectronicChance { get; set; }

        /// <summary>
        /// falloff_attribute_id integer
        /// </summary>
        /// <value>falloff_attribute_id integer</value>
        [JsonProperty("falloff_attribute_id")]
        public int? FalloffAttributeId { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonProperty("icon_id")]
        public int? IconId { get; set; }

        /// <summary>
        /// is_assistance boolean
        /// </summary>
        /// <value>is_assistance boolean</value>
        [JsonProperty("is_assistance")]
        public bool? IsAssistance { get; set; }

        /// <summary>
        /// is_offensive boolean
        /// </summary>
        /// <value>is_offensive boolean</value>
        [JsonProperty("is_offensive")]
        public bool? IsOffensive { get; set; }

        /// <summary>
        /// is_warp_safe boolean
        /// </summary>
        /// <value>is_warp_safe boolean</value>
        [JsonProperty("is_warp_safe")]
        public bool? IsWarpSafe { get; set; }

        /// <summary>
        /// modifiers array
        /// </summary>
        /// <value>modifiers array</value>
        [JsonProperty("modifiers")]
        public List<EffectModifier> Modifiers { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// post_expression integer
        /// </summary>
        /// <value>post_expression integer</value>
        [JsonProperty("post_expression")]
        public int? PostExpression { get; set; }

        /// <summary>
        /// pre_expression integer
        /// </summary>
        /// <value>pre_expression integer</value>
        [JsonProperty("pre_expression")]
        public int? PreExpression { get; set; }
        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [JsonProperty("published")]
        public bool? Published { get; set; }
        /// <summary>
        /// range_attribute_id integer
        /// </summary>
        /// <value>range_attribute_id integer</value>
        [JsonProperty("range_attribute_id")]
        public int? RangeAttributeId { get; set; }

        /// <summary>
        /// range_chance boolean
        /// </summary>
        /// <value>range_chance boolean</value>
        [JsonProperty("range_chance")]
        public bool? RangeChance { get; set; }
        /// <summary>
        /// tracking_speed_attribute_id integer
        /// </summary>
        /// <value>tracking_speed_attribute_id integer</value>
        [JsonProperty("tracking_speed_attribute_id")]
        public int? TrackingSpeedAttributeId { get; set; }

        #endregion Properties
    }

    public class EffectModifier : ModelBase<EffectModifier>
    {
        #region Properties

        /// <summary>
        /// domain string
        /// </summary>
        /// <value>domain string</value>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// effect_id integer
        /// </summary>
        /// <value>effect_id integer</value>
        [JsonProperty("effect_id")]
        public int? EffectId { get; set; }

        /// <summary>
        /// func string
        /// </summary>
        /// <value>func string</value>
        [JsonProperty("func")]
        public string Func { get; set; }
        /// <summary>
        /// modified_attribute_id integer
        /// </summary>
        /// <value>modified_attribute_id integer</value>
        [JsonProperty("modified_attribute_id")]
        public int? ModifiedAttributeId { get; set; }

        /// <summary>
        /// modifying_attribute_id integer
        /// </summary>
        /// <value>modifying_attribute_id integer</value>
        [JsonProperty("modifying_attribute_id")]
        public int? ModifyingAttributeId { get; set; }
        /// <summary>
        /// operator integer
        /// </summary>
        /// <value>operator integer</value>
        [JsonProperty("operator")]
        public int? Operator { get; set; }

        #endregion Properties
    }
}
