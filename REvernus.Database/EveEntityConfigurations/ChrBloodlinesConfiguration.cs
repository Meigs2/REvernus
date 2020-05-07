namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class ChrBloodlinesConfiguration : IEntityTypeConfiguration<ChrBloodlines>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<ChrBloodlines> builder)
        {
            builder.HasKey(e => e.BloodlineId);

            builder.ToTable("chrBloodlines");

            builder.Property(e => e.BloodlineId)
                .HasColumnName("bloodlineID")
                .ValueGeneratedNever();

            builder.Property(e => e.BloodlineName)
                .HasColumnName("bloodlineName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Charisma).HasColumnName("charisma");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.FemaleDescription)
                .HasColumnName("femaleDescription")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Intelligence).HasColumnName("intelligence");

            builder.Property(e => e.MaleDescription)
                .HasColumnName("maleDescription")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.Memory).HasColumnName("memory");

            builder.Property(e => e.Perception).HasColumnName("perception");

            builder.Property(e => e.RaceId).HasColumnName("raceID");

            builder.Property(e => e.ShipTypeId).HasColumnName("shipTypeID");

            builder.Property(e => e.ShortDescription)
                .HasColumnName("shortDescription")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.ShortFemaleDescription)
                .HasColumnName("shortFemaleDescription")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.ShortMaleDescription)
                .HasColumnName("shortMaleDescription")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.Willpower).HasColumnName("willpower");
        }
    }
}
