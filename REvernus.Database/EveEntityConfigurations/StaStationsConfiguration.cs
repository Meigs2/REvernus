namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class StaStationsConfiguration : IEntityTypeConfiguration<StaStations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<StaStations> builder)
        {
            builder.HasKey(e => e.StationId);

            builder.ToTable("staStations");

            builder.HasIndex(e => e.ConstellationId)
                .HasName("ix_staStations_constellationID");

            builder.HasIndex(e => e.CorporationId)
                .HasName("ix_staStations_corporationID");

            builder.HasIndex(e => e.OperationId)
                .HasName("ix_staStations_operationID");

            builder.HasIndex(e => e.RegionId)
                .HasName("ix_staStations_regionID");

            builder.HasIndex(e => e.SolarSystemId)
                .HasName("ix_staStations_solarSystemID");

            builder.HasIndex(e => e.StationTypeId)
                .HasName("ix_staStations_stationTypeID");

            builder.Property(e => e.StationId)
                .HasColumnName("stationID")
                .HasColumnType("BIGINT")
                .ValueGeneratedNever();

            builder.Property(e => e.ConstellationId).HasColumnName("constellationID");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.DockingCostPerVolume)
                .HasColumnName("dockingCostPerVolume")
                .HasColumnType("FLOAT");

            builder.Property(e => e.MaxShipVolumeDockable)
                .HasColumnName("maxShipVolumeDockable")
                .HasColumnType("FLOAT");

            builder.Property(e => e.OfficeRentalCost).HasColumnName("officeRentalCost");

            builder.Property(e => e.OperationId).HasColumnName("operationID");

            builder.Property(e => e.RegionId).HasColumnName("regionID");

            builder.Property(e => e.ReprocessingEfficiency)
                .HasColumnName("reprocessingEfficiency")
                .HasColumnType("FLOAT");

            builder.Property(e => e.ReprocessingHangarFlag).HasColumnName("reprocessingHangarFlag");

            builder.Property(e => e.ReprocessingStationsTake)
                .HasColumnName("reprocessingStationsTake")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Security)
                .HasColumnName("security")
                .HasColumnType("FLOAT");

            builder.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

            builder.Property(e => e.StationName)
                .HasColumnName("stationName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.StationTypeId).HasColumnName("stationTypeID");

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
