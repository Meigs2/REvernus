namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class WarCombatZoneSystems
    {
        public long? CombatZoneId { get; set; }
        public long SolarSystemId { get; set; }
    }
}