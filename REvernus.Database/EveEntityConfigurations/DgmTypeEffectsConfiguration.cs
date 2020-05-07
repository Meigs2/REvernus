namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmTypeEffectsConfiguration : IEntityTypeConfiguration<DgmTypeEffects>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmTypeEffects> builder)
        {
            builder.HasKey(e => new { e.TypeId, e.EffectId });

            builder.ToTable("dgmTypeEffects");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.EffectId).HasColumnName("effectID");

            builder.Property(e => e.IsDefault)
                .HasColumnName("isDefault")
                .HasColumnType("BOOLEAN");
        }
    }
}
