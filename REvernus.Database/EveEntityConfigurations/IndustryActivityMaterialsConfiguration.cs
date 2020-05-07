namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivityMaterialsConfiguration : IEntityTypeConfiguration<IndustryActivityMaterials>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivityMaterials> builder)
        {
            builder.HasNoKey();

            builder.ToTable("industryActivityMaterials");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_industryActivityMaterials_typeID");

            builder.HasIndex(e => new { e.TypeId, e.ActivityId })
                .HasName("industryActivityMaterials_idx1");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.MaterialTypeId).HasColumnName("materialTypeID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
