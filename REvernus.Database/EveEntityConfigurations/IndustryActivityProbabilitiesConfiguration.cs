namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivityProbabilitiesConfiguration : IEntityTypeConfiguration<IndustryActivityProbabilities>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivityProbabilities> builder)
        {
            builder.HasNoKey();

            builder.ToTable("industryActivityProbabilities");

            builder.HasIndex(e => e.ProductTypeId)
                .HasName("ix_industryActivityProbabilities_productTypeID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_industryActivityProbabilities_typeID");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.Probability)
                .HasColumnName("probability")
                .HasColumnType("DECIMAL(3, 2)");

            builder.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
