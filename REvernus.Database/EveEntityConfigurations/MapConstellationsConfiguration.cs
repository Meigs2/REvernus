namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapConstellationsConfiguration : IEntityTypeConfiguration<MapConstellations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapConstellations> builder)
        {
            builder.HasKey(e => e.ConstellationId);

            builder.ToTable("mapConstellations");

            builder.Property(e => e.ConstellationId)
                .HasColumnName("constellationID")
                .ValueGeneratedNever();

            builder.Property(e => e.ConstellationName)
                .HasColumnName("constellationName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.RegionId).HasColumnName("regionID");

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
