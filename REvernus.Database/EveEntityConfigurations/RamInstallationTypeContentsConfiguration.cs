namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamInstallationTypeContentsConfiguration : IEntityTypeConfiguration<RamInstallationTypeContents>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamInstallationTypeContents> builder)
        {
            builder.HasKey(e => new { e.InstallationTypeId, e.AssemblyLineTypeId });

            builder.ToTable("ramInstallationTypeContents");

            builder.Property(e => e.InstallationTypeId).HasColumnName("installationTypeID");

            builder.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");
        }
    }
}
