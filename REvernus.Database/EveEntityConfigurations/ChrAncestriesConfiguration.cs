namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class ChrAncestriesConfiguration : IEntityTypeConfiguration<ChrAncestries>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<ChrAncestries> builder)
        {
            builder.HasKey(e => e.AncestryId);

            builder.ToTable("chrAncestries");

            builder.Property(e => e.AncestryId)
                .HasColumnName("ancestryID")
                .ValueGeneratedNever();

            builder.Property(e => e.AncestryName)
                .HasColumnName("ancestryName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.BloodlineId).HasColumnName("bloodlineID");

            builder.Property(e => e.Charisma).HasColumnName("charisma");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Intelligence).HasColumnName("intelligence");

            builder.Property(e => e.Memory).HasColumnName("memory");

            builder.Property(e => e.Perception).HasColumnName("perception");

            builder.Property(e => e.ShortDescription)
                .HasColumnName("shortDescription")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.Willpower).HasColumnName("willpower");
        }
    }
}
