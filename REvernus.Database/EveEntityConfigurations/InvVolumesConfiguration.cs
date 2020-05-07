namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvVolumesConfiguration : IEntityTypeConfiguration<InvVolumes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvVolumes> builder)
        {
            builder.HasKey(e => e.TypeId);

            builder.ToTable("invVolumes");

            builder.Property(e => e.TypeId)
                .HasColumnName("typeID")
                .ValueGeneratedNever();

            builder.Property(e => e.Volume).HasColumnName("volume");
        }
    }
}
