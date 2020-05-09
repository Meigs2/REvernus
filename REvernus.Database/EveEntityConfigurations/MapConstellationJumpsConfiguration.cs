namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapConstellationJumpsConfiguration : IEntityTypeConfiguration<MapConstellationJumps>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapConstellationJumps> builder)
        {
            builder.HasKey(e => new { e.FromConstellationId, e.ToConstellationId });

            builder.ToTable("mapConstellationJumps");

            builder.Property(e => e.FromConstellationId).HasColumnName("fromConstellationID");

            builder.Property(e => e.ToConstellationId).HasColumnName("toConstellationID");

            builder.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

            builder.Property(e => e.ToRegionId).HasColumnName("toRegionID");
        }
    }
}
