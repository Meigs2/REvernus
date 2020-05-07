namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvContrabandTypesConfiguration : IEntityTypeConfiguration<InvContrabandTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvContrabandTypes> builder)
        {
            builder.HasKey(e => new { e.FactionId, e.TypeId });

            builder.ToTable("invContrabandTypes");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_invContrabandTypes_typeID");

            builder.Property(e => e.FactionId).HasColumnName("factionID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.AttackMinSec)
                .HasColumnName("attackMinSec")
                .HasColumnType("FLOAT");

            builder.Property(e => e.ConfiscateMinSec)
                .HasColumnName("confiscateMinSec")
                .HasColumnType("FLOAT");

            builder.Property(e => e.FineByValue)
                .HasColumnName("fineByValue")
                .HasColumnType("FLOAT");

            builder.Property(e => e.StandingLoss)
                .HasColumnName("standingLoss")
                .HasColumnType("FLOAT");
        }
    }
}
