namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvTypeReactions
    {
        public byte[] Input { get; set; }
        public long? Quantity { get; set; }
        public long ReactionTypeId { get; set; }
        public long TypeId { get; set; }
    }
}