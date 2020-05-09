namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvControlTowerResourcesConfiguration : IEntityTypeConfiguration<InvControlTowerResources>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvControlTowerResources> builder)
        {
            builder.HasKey(e => new { e.ControlTowerTypeId, e.ResourceTypeId });

            builder.ToTable("invControlTowerResources");

            builder.Property(e => e.ControlTowerTypeId).HasColumnName("controlTowerTypeID");

            builder.Property(e => e.ResourceTypeId).HasColumnName("resourceTypeID");

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.MinSecurityLevel)
                .HasColumnName("minSecurityLevel")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Purpose).HasColumnName("purpose");

            builder.Property(e => e.Quantity).HasColumnName("quantity");
        }
    }
}
