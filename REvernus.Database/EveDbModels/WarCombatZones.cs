namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class WarCombatZones
    {
        public long CombatZoneId { get; set; }
        public string CombatZoneName { get; set; }
        public long? FactionId { get; set; }
        public long? CenterSystemId { get; set; }
        public string Description { get; set; }
    }
}
