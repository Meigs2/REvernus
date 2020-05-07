namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivitySkillsConfiguration : IEntityTypeConfiguration<IndustryActivitySkills>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivitySkills> builder)
        {
            builder.HasNoKey();

            builder.ToTable("industryActivitySkills");

            builder.HasIndex(e => e.SkillId)
                .HasName("ix_industryActivitySkills_skillID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_industryActivitySkills_typeID");

            builder.HasIndex(e => new { e.TypeId, e.ActivityId })
                .HasName("industryActivitySkills_idx1");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.Level).HasColumnName("level");

            builder.Property(e => e.SkillId).HasColumnName("skillID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
