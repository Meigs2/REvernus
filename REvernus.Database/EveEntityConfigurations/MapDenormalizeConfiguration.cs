namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapDenormalizeConfiguration : IEntityTypeConfiguration<MapDenormalize>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapDenormalize> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.ToTable("mapDenormalize");

            builder.HasIndex(e => e.ConstellationId)
                .HasName("ix_mapDenormalize_constellationID");

            builder.HasIndex(e => e.OrbitId)
                .HasName("ix_mapDenormalize_orbitID");

            builder.HasIndex(e => e.RegionId)
                .HasName("ix_mapDenormalize_regionID");

            builder.HasIndex(e => e.SolarSystemId)
                .HasName("ix_mapDenormalize_solarSystemID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_mapDenormalize_typeID");

            builder.HasIndex(e => new { e.GroupId, e.ConstellationId })
                .HasName("mapDenormalize_IX_groupConstellation");

            builder.HasIndex(e => new { e.GroupId, e.RegionId })
                .HasName("mapDenormalize_IX_groupRegion");

            builder.HasIndex(e => new { e.GroupId, e.SolarSystemId })
                .HasName("mapDenormalize_IX_groupSystem");

            builder.Property(e => e.ItemId)
                .HasColumnName("itemID")
                .ValueGeneratedNever();

            builder.Property(e => e.CelestialIndex).HasColumnName("celestialIndex");

            builder.Property(e => e.ConstellationId).HasColumnName("constellationID");

            builder.Property(e => e.GroupId).HasColumnName("groupID");

            builder.Property(e => e.ItemName)
                .HasColumnName("itemName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.OrbitId).HasColumnName("orbitID");

            builder.Property(e => e.OrbitIndex).HasColumnName("orbitIndex");

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.RegionId).HasColumnName("regionID");

            builder.Property(e => e.Security)
                .HasColumnName("security")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.X)
                .HasColumnName("x")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Y)
                .HasColumnName("y")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Z)
                .HasColumnName("z")
                .HasColumnType("FLOAT");
        }
    }
}
