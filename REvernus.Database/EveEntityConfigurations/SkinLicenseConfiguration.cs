namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class SkinLicenseConfiguration : IEntityTypeConfiguration<SkinLicense>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<SkinLicense> builder)
        {
            builder.HasKey(e => e.LicenseTypeId);

            builder.ToTable("skinLicense");

            builder.Property(e => e.LicenseTypeId)
                .HasColumnName("licenseTypeID")
                .ValueGeneratedNever();

            builder.Property(e => e.Duration).HasColumnName("duration");

            builder.Property(e => e.SkinId).HasColumnName("skinID");
        }
    }
}
