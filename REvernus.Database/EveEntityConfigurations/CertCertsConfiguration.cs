namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CertCertsConfiguration : IEntityTypeConfiguration<CertCerts>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CertCerts> builder)
        {
            builder.HasKey(e => e.CertId);

            builder.ToTable("certCerts");

            builder.Property(e => e.CertId)
                .HasColumnName("certID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.GroupId).HasColumnName("groupID");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(255)");
        }
}
}
