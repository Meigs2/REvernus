namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class StaServicesConfiguration : IEntityTypeConfiguration<StaServices>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<StaServices> builder)
        {
            builder.HasKey(e => e.ServiceId);

            builder.ToTable("staServices");

            builder.Property(e => e.ServiceId)
                .HasColumnName("serviceID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.ServiceName)
                .HasColumnName("serviceName")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
