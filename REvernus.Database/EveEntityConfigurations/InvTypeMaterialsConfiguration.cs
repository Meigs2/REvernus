namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvTypeMaterialsConfiguration : IEntityTypeConfiguration<InvTypeMaterials>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvTypeMaterials> builder)
        {
            builder.HasKey(e => new { e.TypeId, e.MaterialTypeId });

            builder.ToTable("invTypeMaterials");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.MaterialTypeId).HasColumnName("materialTypeID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");
        }
    }
}
