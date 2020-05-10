namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvControlTowerResourcePurposes
    {
        public long Purpose { get; set; }
        public string PurposeText { get; set; }
    }
}