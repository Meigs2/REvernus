namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class PlanetSchematicsPinMapConfiguration : IEntityTypeConfiguration<PlanetSchematicsPinMap>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<PlanetSchematicsPinMap> builder)
        {
            builder.HasKey(e => new { e.SchematicId, e.PinTypeId });

            builder.ToTable("planetSchematicsPinMap");

            builder.Property(e => e.SchematicId).HasColumnName("schematicID");

            builder.Property(e => e.PinTypeId).HasColumnName("pinTypeID");
        }
    }
}
