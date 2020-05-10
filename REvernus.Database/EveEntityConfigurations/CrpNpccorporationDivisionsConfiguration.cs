namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    public class CrpNpccorporationDivisionsConfiguration : IEntityTypeConfiguration<CrpNpccorporationDivisions>
    {
        public void Configure(EntityTypeBuilder<CrpNpccorporationDivisions> builder)
        {
            builder.HasKey(e => new { e.CorporationId, e.DivisionId });

            builder.ToTable("crpNPCCorporationDivisions");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.DivisionId).HasColumnName("divisionID");

            builder.Property(e => e.Size).HasColumnName("size");
        }
    }
}
