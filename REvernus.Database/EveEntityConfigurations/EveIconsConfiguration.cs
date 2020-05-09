namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class EveIconsConfiguration : IEntityTypeConfiguration<EveIcons>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<EveIcons> builder)
        {
            builder.HasKey(e => e.IconId);

            builder.ToTable("eveIcons");

            builder.Property(e => e.IconId)
                .HasColumnName("iconID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.IconFile)
                .HasColumnName("iconFile")
                .HasColumnType("VARCHAR(500)");
        }
    }
}
