namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class ChrRacesConfiguration : IEntityTypeConfiguration<ChrRaces>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<ChrRaces> builder)
        {
            builder.HasKey(e => e.RaceId);

            builder.ToTable("chrRaces");

            builder.Property(e => e.RaceId)
                .HasColumnName("raceID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.RaceName)
                .HasColumnName("raceName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.ShortDescription)
                .HasColumnName("shortDescription")
                .HasColumnType("VARCHAR(500)");
        }
    }
}
