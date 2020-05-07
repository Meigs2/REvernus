namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CrpNpccorporationsConfiguration : IEntityTypeConfiguration<CrpNpccorporations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CrpNpccorporations> builder)
        {
            builder.HasKey(e => e.CorporationId);

            builder.ToTable("crpNPCCorporations");

            builder.Property(e => e.CorporationId)
                .HasColumnName("corporationID")
                .ValueGeneratedNever();

            builder.Property(e => e.Border).HasColumnName("border");

            builder.Property(e => e.Corridor).HasColumnName("corridor");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(4000)");

            builder.Property(e => e.EnemyId).HasColumnName("enemyID");

            builder.Property(e => e.Extent)
                .HasColumnName("extent")
                .HasColumnType("CHAR(1)");

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.FriendId).HasColumnName("friendID");

            builder.Property(e => e.Fringe).HasColumnName("fringe");

            builder.Property(e => e.Hub).HasColumnName("hub");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.InitialPrice).HasColumnName("initialPrice");

            builder.Property(e => e.InvestorId1).HasColumnName("investorID1");

            builder.Property(e => e.InvestorId2).HasColumnName("investorID2");

            builder.Property(e => e.InvestorId3).HasColumnName("investorID3");

            builder.Property(e => e.InvestorId4).HasColumnName("investorID4");

            builder.Property(e => e.InvestorShares1).HasColumnName("investorShares1");

            builder.Property(e => e.InvestorShares2).HasColumnName("investorShares2");

            builder.Property(e => e.InvestorShares3).HasColumnName("investorShares3");

            builder.Property(e => e.InvestorShares4).HasColumnName("investorShares4");

            builder.Property(e => e.MinSecurity)
                .HasColumnName("minSecurity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.PublicShares).HasColumnName("publicShares");

            builder.Property(e => e.Scattered)
                .HasColumnName("scattered")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("CHAR(1)");

            builder.Property(e => e.SizeFactor)
                .HasColumnName("sizeFactor")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

            builder.Property(e => e.StationCount).HasColumnName("stationCount");

            builder.Property(e => e.StationSystemCount).HasColumnName("stationSystemCount");
        }
    }
}
