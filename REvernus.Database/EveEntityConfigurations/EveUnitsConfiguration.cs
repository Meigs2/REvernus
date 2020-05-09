namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class EveUnitsConfiguration : IEntityTypeConfiguration<EveUnits>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<EveUnits> builder)
        {
            builder.HasKey(e => e.UnitId);

            builder.ToTable("eveUnits");

            builder.Property(e => e.UnitId)
                .HasColumnName("unitID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.DisplayName)
                .HasColumnName("displayName")
                .HasColumnType("VARCHAR(50)");

            builder.Property(e => e.UnitName)
                .HasColumnName("unitName")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
