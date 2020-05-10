namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class DgmTypeEffects
    {
        public long EffectId { get; set; }
        public byte[] IsDefault { get; set; }
        public long TypeId { get; set; }
    }
}