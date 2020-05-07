namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class ChrFactionsConfiguration : IEntityTypeConfiguration<ChrFactions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<ChrFactions> builder)
        {
            builder.HasKey(e => e.FactionId);

            builder.ToTable("chrFactions");

            builder.Property(e => e.FactionId)
                .HasColumnName("factionID")
                .ValueGeneratedNever();

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.FactionName)
                .HasColumnName("factionName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.MilitiaCorporationId).HasColumnName("militiaCorporationID");

            builder.Property(e => e.RaceIds).HasColumnName("raceIDs");

            builder.Property(e => e.SizeFactor)
                .HasColumnName("sizeFactor")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

            builder.Property(e => e.StationCount).HasColumnName("stationCount");

            builder.Property(e => e.StationSystemCount).HasColumnName("stationSystemCount");
        }
    }
}
