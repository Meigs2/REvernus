namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmTypeAttributesConfiguration : IEntityTypeConfiguration<DgmTypeAttributes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmTypeAttributes> builder)
        {
            builder.HasKey(e => new { e.TypeId, e.AttributeId });

            builder.ToTable("dgmTypeAttributes");

            builder.HasIndex(e => e.AttributeId)
                .HasName("ix_dgmTypeAttributes_attributeID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.AttributeId).HasColumnName("attributeID");

            builder.Property(e => e.ValueFloat)
                .HasColumnName("valueFloat")
                .HasColumnType("FLOAT");

            builder.Property(e => e.ValueInt).HasColumnName("valueInt");
        }
    }
}
