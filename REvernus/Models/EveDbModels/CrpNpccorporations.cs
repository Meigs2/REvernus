namespace REvernus.Models.EveDbModels
{
    public partial class CrpNpccorporations
    {
        public long CorporationId { get; set; }
        public string Size { get; set; }
        public string Extent { get; set; }
        public long? SolarSystemId { get; set; }
        public long? InvestorId1 { get; set; }
        public long? InvestorShares1 { get; set; }
        public long? InvestorId2 { get; set; }
        public long? InvestorShares2 { get; set; }
        public long? InvestorId3 { get; set; }
        public long? InvestorShares3 { get; set; }
        public long? InvestorId4 { get; set; }
        public long? InvestorShares4 { get; set; }
        public long? FriendId { get; set; }
        public long? EnemyId { get; set; }
        public long? PublicShares { get; set; }
        public long? InitialPrice { get; set; }
        public double? MinSecurity { get; set; }
        public byte[] Scattered { get; set; }
        public long? Fringe { get; set; }
        public long? Corridor { get; set; }
        public long? Hub { get; set; }
        public long? Border { get; set; }
        public long? FactionId { get; set; }
        public double? SizeFactor { get; set; }
        public long? StationCount { get; set; }
        public long? StationSystemCount { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
    }
}
