namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class EveGraphicsConfiguration : IEntityTypeConfiguration<EveGraphics>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<EveGraphics> builder)
        {
            builder.HasKey(e => e.GraphicId);

            builder.ToTable("eveGraphics");

            builder.Property(e => e.GraphicId)
                .HasColumnName("graphicID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.GraphicFile)
                .HasColumnName("graphicFile")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.SofFactionName)
                .HasColumnName("sofFactionName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.SofHullName)
                .HasColumnName("sofHullName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.SofRaceName)
                .HasColumnName("sofRaceName")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
