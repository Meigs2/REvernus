namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class WarCombatZonesConfiguration : IEntityTypeConfiguration<WarCombatZones>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<WarCombatZones> builder)
        {
            builder.HasKey(e => e.CombatZoneId);

            builder.ToTable("warCombatZones");

            builder.Property(e => e.CombatZoneId)
                .HasColumnName("combatZoneID")
                .ValueGeneratedNever();

            builder.Property(e => e.CenterSystemId).HasColumnName("centerSystemID");

            builder.Property(e => e.CombatZoneName)
                .HasColumnName("combatZoneName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.FactionId).HasColumnName("factionID");
        }
    }
}
