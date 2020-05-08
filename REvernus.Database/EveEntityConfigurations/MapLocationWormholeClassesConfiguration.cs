namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapLocationWormholeClassesConfiguration : IEntityTypeConfiguration<MapLocationWormholeClasses>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapLocationWormholeClasses> builder)
        {
            builder.HasKey(e => e.LocationId);

            builder.ToTable("mapLocationWormholeClasses");

            builder.Property(e => e.LocationId)
                .HasColumnName("locationID")
                .ValueGeneratedNever();

            builder.Property(e => e.WormholeClassId).HasColumnName("wormholeClassID");
        }
    }
}
