namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class WarCombatZoneSystemsConfiguration : IEntityTypeConfiguration<WarCombatZoneSystems>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<WarCombatZoneSystems> builder)
        {
            builder.HasKey(e => e.SolarSystemId);

            builder.ToTable("warCombatZoneSystems");

            builder.Property(e => e.SolarSystemId)
                .HasColumnName("solarSystemID")
                .ValueGeneratedNever();

            builder.Property(e => e.CombatZoneId).HasColumnName("combatZoneID");
        }
    }
}
