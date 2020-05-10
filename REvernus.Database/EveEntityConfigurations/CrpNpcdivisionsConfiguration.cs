namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CrpNpcdivisionsConfiguration : IEntityTypeConfiguration<CrpNpcdivisions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CrpNpcdivisions> builder)
        {
            builder.HasKey(e => e.DivisionId);

            builder.ToTable("crpNPCDivisions");

            builder.Property(e => e.DivisionId)
                .HasColumnName("divisionID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.DivisionName)
                .HasColumnName("divisionName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.LeaderType)
                .HasColumnName("leaderType")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
