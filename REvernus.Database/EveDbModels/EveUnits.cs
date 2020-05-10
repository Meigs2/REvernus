namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class EveUnits
    {
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
    }
}