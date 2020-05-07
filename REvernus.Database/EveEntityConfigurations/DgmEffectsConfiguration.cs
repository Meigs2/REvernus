namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmEffectsConfiguration : IEntityTypeConfiguration<DgmEffects>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmEffects> builder)
        {
            builder.HasKey(e => e.EffectId);

            builder.ToTable("dgmEffects");

            builder.Property(e => e.EffectId)
                .HasColumnName("effectID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.DisallowAutoRepeat)
                .HasColumnName("disallowAutoRepeat")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.DischargeAttributeId).HasColumnName("dischargeAttributeID");

            builder.Property(e => e.DisplayName)
                .HasColumnName("displayName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Distribution).HasColumnName("distribution");

            builder.Property(e => e.DurationAttributeId).HasColumnName("durationAttributeID");

            builder.Property(e => e.EffectCategory).HasColumnName("effectCategory");

            builder.Property(e => e.EffectName)
                .HasColumnName("effectName")
                .HasColumnType("VARCHAR(400)");

            builder.Property(e => e.ElectronicChance)
                .HasColumnName("electronicChance")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.FalloffAttributeId).HasColumnName("falloffAttributeID");

            builder.Property(e => e.FittingUsageChanceAttributeId).HasColumnName("fittingUsageChanceAttributeID");

            builder.Property(e => e.Guid)
                .HasColumnName("guid")
                .HasColumnType("VARCHAR(60)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.IsAssistance)
                .HasColumnName("isAssistance")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.IsOffensive)
                .HasColumnName("isOffensive")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.IsWarpSafe)
                .HasColumnName("isWarpSafe")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.ModifierInfo).HasColumnName("modifierInfo");

            builder.Property(e => e.NpcActivationChanceAttributeId).HasColumnName("npcActivationChanceAttributeID");

            builder.Property(e => e.NpcUsageChanceAttributeId).HasColumnName("npcUsageChanceAttributeID");

            builder.Property(e => e.PostExpression).HasColumnName("postExpression");

            builder.Property(e => e.PreExpression).HasColumnName("preExpression");

            builder.Property(e => e.PropulsionChance)
                .HasColumnName("propulsionChance")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.RangeAttributeId).HasColumnName("rangeAttributeID");

            builder.Property(e => e.RangeChance)
                .HasColumnName("rangeChance")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.SfxName)
                .HasColumnName("sfxName")
                .HasColumnType("VARCHAR(20)");

            builder.Property(e => e.TrackingSpeedAttributeId).HasColumnName("trackingSpeedAttributeID");
        }
    }
}
