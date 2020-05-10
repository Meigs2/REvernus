namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CertSkillsConfiguration : IEntityTypeConfiguration<CertSkills>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CertSkills> builder)
        {
            builder.HasNoKey();

            builder.ToTable("certSkills");

            builder.HasIndex(e => e.SkillId)
                .HasName("ix_certSkills_skillID");

            builder.Property(e => e.CertId).HasColumnName("certID");

            builder.Property(e => e.CertLevelInt).HasColumnName("certLevelInt");

            builder.Property(e => e.CertLevelText)
                .HasColumnName("certLevelText")
                .HasColumnType("VARCHAR(8)");

            builder.Property(e => e.SkillId).HasColumnName("skillID");

            builder.Property(e => e.SkillLevel).HasColumnName("skillLevel");
        }
    }
}
