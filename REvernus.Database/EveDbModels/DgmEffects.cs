namespace REvernus.Database.EveDbModels
{
    public partial class DgmEffects
    {
        public long EffectId { get; set; }
        public string EffectName { get; set; }
        public long? EffectCategory { get; set; }
        public long? PreExpression { get; set; }
        public long? PostExpression { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public long? IconId { get; set; }
        public byte[] IsOffensive { get; set; }
        public byte[] IsAssistance { get; set; }
        public long? DurationAttributeId { get; set; }
        public long? TrackingSpeedAttributeId { get; set; }
        public long? DischargeAttributeId { get; set; }
        public long? RangeAttributeId { get; set; }
        public long? FalloffAttributeId { get; set; }
        public byte[] DisallowAutoRepeat { get; set; }
        public byte[] Published { get; set; }
        public string DisplayName { get; set; }
        public byte[] IsWarpSafe { get; set; }
        public byte[] RangeChance { get; set; }
        public byte[] ElectronicChance { get; set; }
        public byte[] PropulsionChance { get; set; }
        public long? Distribution { get; set; }
        public string SfxName { get; set; }
        public long? NpcUsageChanceAttributeId { get; set; }
        public long? NpcActivationChanceAttributeId { get; set; }
        public long? FittingUsageChanceAttributeId { get; set; }
        public string ModifierInfo { get; set; }
    }
}
