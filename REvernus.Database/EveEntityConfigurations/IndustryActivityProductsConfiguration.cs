namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivityProductsConfiguration : IEntityTypeConfiguration<IndustryActivityProducts>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivityProducts> builder)
        {
            builder.HasNoKey();

            builder.ToTable("industryActivityProducts");

            builder.HasIndex(e => e.ProductTypeId)
                .HasName("ix_industryActivityProducts_productTypeID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_industryActivityProducts_typeID");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
