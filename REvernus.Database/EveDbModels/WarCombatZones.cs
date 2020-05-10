namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class WarCombatZones
    {
        public long? CenterSystemId { get; set; }
        public long CombatZoneId { get; set; }
        public string CombatZoneName { get; set; }
        public string Description { get; set; }
        public long? FactionId { get; set; }
    }
}