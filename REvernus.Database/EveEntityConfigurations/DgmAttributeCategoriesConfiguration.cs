namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmAttributeCategoriesConfiguration : IEntityTypeConfiguration<DgmAttributeCategories>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmAttributeCategories> builder)
        {
            builder.HasKey(e => e.CategoryId);

            builder.ToTable("dgmAttributeCategories");

            builder.Property(e => e.CategoryId)
                .HasColumnName("categoryID")
                .ValueGeneratedNever();

            builder.Property(e => e.CategoryDescription)
                .HasColumnName("categoryDescription")
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.CategoryName)
                .HasColumnName("categoryName")
                .HasColumnType("VARCHAR(50)");
        }
    }
}
