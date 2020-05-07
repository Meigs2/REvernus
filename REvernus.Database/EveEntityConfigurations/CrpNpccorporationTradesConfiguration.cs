namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CrpNpccorporationTradesConfiguration : IEntityTypeConfiguration<CrpNpccorporationTrades>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CrpNpccorporationTrades> builder)
        {
            builder.HasKey(e => new { e.CorporationId, e.TypeId });

            builder.ToTable("crpNPCCorporationTrades");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
