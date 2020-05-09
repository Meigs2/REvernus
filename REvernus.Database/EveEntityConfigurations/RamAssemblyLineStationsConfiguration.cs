namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamAssemblyLineStationsConfiguration : IEntityTypeConfiguration<RamAssemblyLineStations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamAssemblyLineStations> builder)
        {
            builder.HasKey(e => new { e.StationId, e.AssemblyLineTypeId });

            builder.ToTable("ramAssemblyLineStations");

            builder.HasIndex(e => e.OwnerId)
                .HasName("ix_ramAssemblyLineStations_ownerID");

            builder.HasIndex(e => e.RegionId)
                .HasName("ix_ramAssemblyLineStations_regionID");

            builder.HasIndex(e => e.SolarSystemId)
                .HasName("ix_ramAssemblyLineStations_solarSystemID");

            builder.Property(e => e.StationId).HasColumnName("stationID");

            builder.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

            builder.Property(e => e.OwnerId).HasColumnName("ownerID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.RegionId).HasColumnName("regionID");

            builder.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

            builder.Property(e => e.StationTypeId).HasColumnName("stationTypeID");
        }
    }
}
