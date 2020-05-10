namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class StaOperationServicesConfiguration : IEntityTypeConfiguration<StaOperationServices>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<StaOperationServices> builder)
        {
            builder.HasKey(e => new { e.OperationId, e.ServiceId });

            builder.ToTable("staOperationServices");

            builder.Property(e => e.OperationId).HasColumnName("operationID");

            builder.Property(e => e.ServiceId).HasColumnName("serviceID");
        }
    }
}
