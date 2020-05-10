namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvMarketGroups
    {
        public string Description { get; set; }
        public byte[] HasTypes { get; set; }
        public long? IconId { get; set; }
        public long MarketGroupId { get; set; }
        public string MarketGroupName { get; set; }
        public long? ParentGroupId { get; set; }
    }
}