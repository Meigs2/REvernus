namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class EveUnits
    {
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
