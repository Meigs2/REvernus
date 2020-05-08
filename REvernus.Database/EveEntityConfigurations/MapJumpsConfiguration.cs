namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapJumpsConfiguration : IEntityTypeConfiguration<MapJumps>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapJumps> builder)
        {
            builder.HasKey(e => e.StargateId);

            builder.ToTable("mapJumps");

            builder.Property(e => e.StargateId)
                .HasColumnName("stargateID")
                .ValueGeneratedNever();

            builder.Property(e => e.DestinationId).HasColumnName("destinationID");
        }
    }
}
