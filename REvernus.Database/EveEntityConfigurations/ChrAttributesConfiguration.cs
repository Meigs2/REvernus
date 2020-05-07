namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class ChrAttributesConfiguration : IEntityTypeConfiguration<ChrAttributes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<ChrAttributes> builder)
        {
            builder.HasKey(e => e.AttributeId);

            builder.ToTable("chrAttributes");

            builder.Property(e => e.AttributeId)
                .HasColumnName("attributeID")
                .ValueGeneratedNever();

            builder.Property(e => e.AttributeName)
                .HasColumnName("attributeName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.ShortDescription)
                .HasColumnName("shortDescription")
                .HasColumnType("VARCHAR(500)");
        }
    }
}
