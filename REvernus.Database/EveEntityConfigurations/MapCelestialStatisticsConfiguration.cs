namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapCelestialStatisticsConfiguration : IEntityTypeConfiguration<MapCelestialStatistics>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapCelestialStatistics> builder)
        {
            builder.HasKey(e => e.CelestialId);

            builder.ToTable("mapCelestialStatistics");

            builder.Property(e => e.CelestialId)
                .HasColumnName("celestialID")
                .ValueGeneratedNever();

            builder.Property(e => e.Age)
                .HasColumnName("age")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Density)
                .HasColumnName("density")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Eccentricity)
                .HasColumnName("eccentricity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.EscapeVelocity)
                .HasColumnName("escapeVelocity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Fragmented)
                .HasColumnName("fragmented")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Life)
                .HasColumnName("life")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Locked)
                .HasColumnName("locked")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Luminosity)
                .HasColumnName("luminosity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Mass).HasColumnName("mass");

            builder.Property(e => e.MassDust)
                .HasColumnName("massDust")
                .HasColumnType("FLOAT");

            builder.Property(e => e.MassGas)
                .HasColumnName("massGas")
                .HasColumnType("FLOAT");

            builder.Property(e => e.OrbitPeriod)
                .HasColumnName("orbitPeriod")
                .HasColumnType("FLOAT");

            builder.Property(e => e.OrbitRadius)
                .HasColumnName("orbitRadius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Pressure)
                .HasColumnName("pressure")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.RotationRate)
                .HasColumnName("rotationRate")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SpectralClass)
                .HasColumnName("spectralClass")
                .HasColumnType("VARCHAR(10)");

            builder.Property(e => e.SurfaceGravity)
                .HasColumnName("surfaceGravity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Temperature)
                .HasColumnName("temperature")
                .HasColumnType("FLOAT");
        }
    }
}
