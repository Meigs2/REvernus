namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvFlagsConfiguration : IEntityTypeConfiguration<InvFlags>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvFlags> builder)
        {
            builder.HasKey(e => e.FlagId);

            builder.ToTable("invFlags");

            builder.Property(e => e.FlagId)
                .HasColumnName("flagID")
                .ValueGeneratedNever();

            builder.Property(e => e.FlagName)
                .HasColumnName("flagName")
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.FlagText)
                .HasColumnName("flagText")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.OrderId).HasColumnName("orderID");
        }
    }
}
