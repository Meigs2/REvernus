namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CertMasteriesConfiguration : IEntityTypeConfiguration<CertMasteries>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CertMasteries> builder)
        {
            builder.HasNoKey();

            builder.ToTable("certMasteries");

            builder.Property(e => e.CertId).HasColumnName("certID");

            builder.Property(e => e.MasteryLevel).HasColumnName("masteryLevel");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
