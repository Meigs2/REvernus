namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapUniverseConfiguration : IEntityTypeConfiguration<MapUniverse>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapUniverse> builder)
        {
            builder.HasKey(e => e.UniverseId);

            builder.ToTable("mapUniverse");

            builder.Property(e => e.UniverseId)
                .HasColumnName("universeID")
                .ValueGeneratedNever();

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.UniverseName)
                .HasColumnName("universeName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.X)
                .HasColumnName("x")
                .HasColumnType("FLOAT");

            builder.Property(e => e.XMax)
                .HasColumnName("xMax")
                .HasColumnType("FLOAT");

            builder.Property(e => e.XMin)
                .HasColumnName("xMin")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Y)
                .HasColumnName("y")
                .HasColumnType("FLOAT");

            builder.Property(e => e.YMax)
                .HasColumnName("yMax")
                .HasColumnType("FLOAT");

            builder.Property(e => e.YMin)
                .HasColumnName("yMin")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Z)
                .HasColumnName("z")
                .HasColumnType("FLOAT");

            builder.Property(e => e.ZMax)
                .HasColumnName("zMax")
                .HasColumnType("FLOAT");

            builder.Property(e => e.ZMin)
                .HasColumnName("zMin")
                .HasColumnType("FLOAT");
        }
    }
}
