namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapRegionsConfiguration : IEntityTypeConfiguration<MapRegions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapRegions> builder)
        {
            builder.HasKey(e => e.RegionId);

            builder.ToTable("mapRegions");

            builder.Property(e => e.RegionId)
                .HasColumnName("regionID")
                .ValueGeneratedNever();

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.Radius)
                .HasColumnName("radius")
                .HasColumnType("FLOAT");

            builder.Property(e => e.RegionName)
                .HasColumnName("regionName")
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
