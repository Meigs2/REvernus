namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class StaOperationsConfiguration : IEntityTypeConfiguration<StaOperations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<StaOperations> builder)
        {
            builder.HasKey(e => e.OperationId);

            builder.ToTable("staOperations");

            builder.Property(e => e.OperationId)
                .HasColumnName("operationID")
                .ValueGeneratedNever();

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.AmarrStationTypeId).HasColumnName("amarrStationTypeID");

            builder.Property(e => e.Border).HasColumnName("border");

            builder.Property(e => e.CaldariStationTypeId).HasColumnName("caldariStationTypeID");

            builder.Property(e => e.Corridor).HasColumnName("corridor");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.Fringe).HasColumnName("fringe");

            builder.Property(e => e.GallenteStationTypeId).HasColumnName("gallenteStationTypeID");

            builder.Property(e => e.Hub).HasColumnName("hub");

            builder.Property(e => e.JoveStationTypeId).HasColumnName("joveStationTypeID");

            builder.Property(e => e.MinmatarStationTypeId).HasColumnName("minmatarStationTypeID");

            builder.Property(e => e.OperationName)
                .HasColumnName("operationName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Ratio).HasColumnName("ratio");
        }
    }
}
