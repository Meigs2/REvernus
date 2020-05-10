namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapSolarSystemsConfiguration : IEntityTypeConfiguration<MapSolarSystems>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapSolarSystems> builder)
        {
            builder.HasKey(e => e.SolarSystemId);

            builder.ToTable("mapSolarSystems");

            builder.HasIndex(e => e.ConstellationId)
                .HasName("ix_mapSolarSystems_constellationID");

            builder.HasIndex(e => e.RegionId)
                .HasName("ix_mapSolarSystems_regionID");

            builder.HasIndex(e => e.Security)
                .HasName("ix_mapSolarSystems_security");

            builder.Property(e => e.SolarSystemId)
                .HasColumnName("solarSystemID")
                .ValueGeneratedNever();

            builder.Property(e => e.Border)
                .HasColumnName("border")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Constellation)
                .HasColumnName("constellation")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.ConstellationId).HasColumnName("constellationID");

            builder.Property(e => e.Corridor)
                .HasColumnName("corridor")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.Fringe)
                .HasColumnName("fringe")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Hub)
                .HasColumnName("hub")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.International)
                .HasColumnName("international")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Luminosity)
                .HasColumnName("luminosity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.RegionId).HasColumnName("regionID");

            builder.Property(e => e.Regional)
                .HasColumnName("regional")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Security)
                .HasColumnName("security")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SecurityClass)
                .HasColumnName("securityClass")
                .HasColumnType("VARCHAR(2)");

            builder.Property(e => e.SolarSystemName)
                .HasColumnName("solarSystemName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.SunTypeId).HasColumnName("sunTypeID");

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
