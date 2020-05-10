namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class PlanetSchematicsConfiguration : IEntityTypeConfiguration<PlanetSchematics>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<PlanetSchematics> builder)
        {
            builder.HasKey(e => e.SchematicId);

            builder.ToTable("planetSchematics");

            builder.Property(e => e.SchematicId)
                .HasColumnName("schematicID")
                .ValueGeneratedNever();

            builder.Property(e => e.CycleTime).HasColumnName("cycleTime");

            builder.Property(e => e.SchematicName)
                .HasColumnName("schematicName")
                .HasColumnType("VARCHAR(255)");
        }
    }
}
