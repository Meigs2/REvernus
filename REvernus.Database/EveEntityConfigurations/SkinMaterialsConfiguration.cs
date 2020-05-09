namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class SkinMaterialsConfiguration : IEntityTypeConfiguration<SkinMaterials>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<SkinMaterials> builder)
        {
            builder.HasKey(e => e.SkinMaterialId);

            builder.ToTable("skinMaterials");

            builder.Property(e => e.SkinMaterialId)
                .HasColumnName("skinMaterialID")
                .ValueGeneratedNever();

            builder.Property(e => e.DisplayNameId).HasColumnName("displayNameID");

            builder.Property(e => e.MaterialSetId).HasColumnName("materialSetID");
        }
    }
}
