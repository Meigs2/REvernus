namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class WarCombatZoneSystems
    {
        public long SolarSystemId { get; set; }
        public long? CombatZoneId { get; set; }
    }
}
