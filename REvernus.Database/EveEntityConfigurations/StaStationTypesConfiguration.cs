namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class StaStationTypesConfiguration : IEntityTypeConfiguration<StaStationTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<StaStationTypes> builder)
        {
            builder.HasKey(e => e.StationTypeId);

            builder.ToTable("staStationTypes");

            builder.Property(e => e.StationTypeId)
                .HasColumnName("stationTypeID")
                .ValueGeneratedNever();

            builder.Property(e => e.Conquerable)
                .HasColumnName("conquerable")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.DockEntryX)
                .HasColumnName("dockEntryX")
                .HasColumnType("FLOAT");

            builder.Property(e => e.DockEntryY)
                .HasColumnName("dockEntryY")
                .HasColumnType("FLOAT");

            builder.Property(e => e.DockEntryZ)
                .HasColumnName("dockEntryZ")
                .HasColumnType("FLOAT");

            builder.Property(e => e.DockOrientationX)
                .HasColumnName("dockOrientationX")
                .HasColumnType("FLOAT");

            builder.Property(e => e.DockOrientationY)
                .HasColumnName("dockOrientationY")
                .HasColumnType("FLOAT");

            builder.Property(e => e.DockOrientationZ)
                .HasColumnName("dockOrientationZ")
                .HasColumnType("FLOAT");

            builder.Property(e => e.OfficeSlots).HasColumnName("officeSlots");

            builder.Property(e => e.OperationId).HasColumnName("operationID");

            builder.Property(e => e.ReprocessingEfficiency)
                .HasColumnName("reprocessingEfficiency")
                .HasColumnType("FLOAT");
        }
    }
}
