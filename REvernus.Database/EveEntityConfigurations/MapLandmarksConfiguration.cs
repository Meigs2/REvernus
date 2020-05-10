namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class MapLandmarksConfiguration : IEntityTypeConfiguration<MapLandmarks>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<MapLandmarks> builder)
        {
            builder.HasKey(e => e.LandmarkId);

            builder.ToTable("mapLandmarks");

            builder.Property(e => e.LandmarkId)
                .HasColumnName("landmarkID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.LandmarkName)
                .HasColumnName("landmarkName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.LocationId).HasColumnName("locationID");

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
