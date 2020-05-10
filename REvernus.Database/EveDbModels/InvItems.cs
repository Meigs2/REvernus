namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvItems
    {
        public long ItemId { get; set; }
        public long TypeId { get; set; }
        public long OwnerId { get; set; }
        public long LocationId { get; set; }
        public long FlagId { get; set; }
        public long Quantity { get; set; }
    }
}
