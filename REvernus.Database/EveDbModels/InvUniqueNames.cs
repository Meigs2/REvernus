namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvUniqueNames
    {
        public long? GroupId { get; set; }
        public long ItemId { get; set; }
        public string ItemName { get; set; }
    }
}