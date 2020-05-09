namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CrpNpccorporationResearchFieldsConfiguration : IEntityTypeConfiguration<CrpNpccorporationResearchFields>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CrpNpccorporationResearchFields> builder)
        {
            builder.HasKey(e => new { e.SkillId, e.CorporationId });

            builder.ToTable("crpNPCCorporationResearchFields");

            builder.Property(e => e.SkillId).HasColumnName("skillID");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");
        }
    }
}
