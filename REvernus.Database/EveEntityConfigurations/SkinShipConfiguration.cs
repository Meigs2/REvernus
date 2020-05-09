namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class SkinShipConfiguration : IEntityTypeConfiguration<SkinShip>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<SkinShip> builder)
        {
            builder.HasNoKey();

            builder.ToTable("skinShip");

            builder.HasIndex(e => e.SkinId)
                .HasName("ix_skinShip_skinID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_skinShip_typeID");

            builder.Property(e => e.SkinId).HasColumnName("skinID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
