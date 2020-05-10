namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    public class InvNames
    {
        [PublicAPI]
        public long ItemId { get; set; }

        public string ItemName { get; set; }
    }
}