namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapLocationScenesConfiguration : IEntityTypeConfiguration<MapLocationScenes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapLocationScenes> builder)
        {
            builder.HasKey(e => e.LocationId);

            builder.ToTable("mapLocationScenes");

            builder.Property(e => e.LocationId)
                .HasColumnName("locationID")
                .ValueGeneratedNever();

            builder.Property(e => e.GraphicId).HasColumnName("graphicID");
        }
    }
}
