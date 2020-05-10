namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvFlags
    {
        public long FlagId { get; set; }
        public string FlagName { get; set; }
        public string FlagText { get; set; }
        public long? OrderId { get; set; }
    }
}
