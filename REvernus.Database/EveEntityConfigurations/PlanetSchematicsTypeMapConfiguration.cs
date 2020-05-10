namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class PlanetSchematicsTypeMapConfiguration : IEntityTypeConfiguration<PlanetSchematicsTypeMap>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<PlanetSchematicsTypeMap> builder)
        {
            builder.HasKey(e => new { e.SchematicId, e.TypeId });

            builder.ToTable("planetSchematicsTypeMap");

            builder.Property(e => e.SchematicId).HasColumnName("schematicID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.IsInput)
                .HasColumnName("isInput")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Quantity).HasColumnName("quantity");
        }
    }
}
