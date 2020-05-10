namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvContrabandTypes
    {
        public double? AttackMinSec { get; set; }
        public double? ConfiscateMinSec { get; set; }
        public long FactionId { get; set; }
        public double? FineByValue { get; set; }
        public double? StandingLoss { get; set; }
        public long TypeId { get; set; }
    }
}