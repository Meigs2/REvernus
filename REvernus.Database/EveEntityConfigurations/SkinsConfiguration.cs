namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class SkinsConfiguration : IEntityTypeConfiguration<Skins>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<Skins> builder)
        {
            builder.HasKey(e => e.SkinId);

            builder.ToTable("skins");

            builder.Property(e => e.SkinId)
                .HasColumnName("skinID")
                .ValueGeneratedNever();

            builder.Property(e => e.InternalName)
                .HasColumnName("internalName")
                .HasColumnType("VARCHAR(70)");

            builder.Property(e => e.SkinMaterialId).HasColumnName("skinMaterialID");
        }
    }
}
