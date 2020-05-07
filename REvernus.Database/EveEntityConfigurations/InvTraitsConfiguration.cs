namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvTraitsConfiguration : IEntityTypeConfiguration<InvTraits>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvTraits> builder)
        {
            builder.HasKey(e => e.TraitId);

            builder.ToTable("invTraits");

            builder.Property(e => e.TraitId)
                .HasColumnName("traitID")
                .ValueGeneratedNever();

            builder.Property(e => e.Bonus)
                .HasColumnName("bonus")
                .HasColumnType("FLOAT");

            builder.Property(e => e.BonusText).HasColumnName("bonusText");

            builder.Property(e => e.SkillId).HasColumnName("skillID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.UnitId).HasColumnName("unitID");
        }
    }
}
