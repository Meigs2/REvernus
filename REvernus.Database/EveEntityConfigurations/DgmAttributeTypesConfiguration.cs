namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmAttributeTypesConfiguration : IEntityTypeConfiguration<DgmAttributeTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmAttributeTypes> builder)
        {
            builder.HasKey(e => e.AttributeId);

            builder.ToTable("dgmAttributeTypes");

            builder.Property(e => e.AttributeId)
                .HasColumnName("attributeID")
                .ValueGeneratedNever();

            builder.Property(e => e.AttributeName)
                .HasColumnName("attributeName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.CategoryId).HasColumnName("categoryID");

            builder.Property(e => e.DefaultValue)
                .HasColumnName("defaultValue")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.DisplayName)
                .HasColumnName("displayName")
                .HasColumnType("VARCHAR(150)");

            builder.Property(e => e.HighIsGood)
                .HasColumnName("highIsGood")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Stackable)
                .HasColumnName("stackable")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.UnitId).HasColumnName("unitID");
        }
    }
}
