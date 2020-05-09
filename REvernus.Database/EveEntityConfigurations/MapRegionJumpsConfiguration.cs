namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapRegionJumpsConfiguration : IEntityTypeConfiguration<MapRegionJumps>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapRegionJumps> builder)
        {
            builder.HasKey(e => new { e.FromRegionId, e.ToRegionId });

            builder.ToTable("mapRegionJumps");

            builder.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

            builder.Property(e => e.ToRegionId).HasColumnName("toRegionID");
        }
    }
}
