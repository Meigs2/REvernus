namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvCategoriesConfiguration : IEntityTypeConfiguration<InvCategories>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvCategories> builder)
        {
            builder.HasKey(e => e.CategoryId);

            builder.ToTable("invCategories");

            builder.Property(e => e.CategoryId)
                .HasColumnName("categoryID")
                .ValueGeneratedNever();

            builder.Property(e => e.CategoryName)
                .HasColumnName("categoryName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");
        }
    }
}
