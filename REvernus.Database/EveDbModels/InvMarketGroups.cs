namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvMarketGroups
    {
        public long MarketGroupId { get; set; }
        public long? ParentGroupId { get; set; }
        public string MarketGroupName { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
        public byte[] HasTypes { get; set; }
    }
}
