namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapSolarSystemJumpsConfiguration : IEntityTypeConfiguration<MapSolarSystemJumps>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapSolarSystemJumps> builder)
        {
            builder.HasKey(e => new { e.FromSolarSystemId, e.ToSolarSystemId });

            builder.ToTable("mapSolarSystemJumps");

            builder.Property(e => e.FromSolarSystemId).HasColumnName("fromSolarSystemID");

            builder.Property(e => e.ToSolarSystemId).HasColumnName("toSolarSystemID");

            builder.Property(e => e.FromConstellationId).HasColumnName("fromConstellationID");

            builder.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

            builder.Property(e => e.ToConstellationId).HasColumnName("toConstellationID");

            builder.Property(e => e.ToRegionId).HasColumnName("toRegionID");
        }
    }
}
