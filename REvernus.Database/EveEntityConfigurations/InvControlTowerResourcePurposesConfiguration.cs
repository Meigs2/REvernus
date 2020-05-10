namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvControlTowerResourcePurposesConfiguration : IEntityTypeConfiguration<InvControlTowerResourcePurposes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvControlTowerResourcePurposes> builder)
        {
            builder.HasKey(e => e.Purpose);

            builder.ToTable("invControlTowerResourcePurposes");

            builder.Property(e => e.Purpose)
                .HasColumnName("purpose")
                .ValueGeneratedNever();

            builder.Property(e => e.PurposeText)
                .HasColumnName("purposeText")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
