namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvNamesConfiguration : IEntityTypeConfiguration<InvNames>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvNames> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.ToTable("invNames");

            builder.Property(e => e.ItemId)
                .HasColumnName("itemID")
                .ValueGeneratedNever();

            builder.Property(e => e.ItemName)
                .IsRequired()
                .HasColumnName("itemName")
                .HasColumnType("VARCHAR(200)");
        }
    }
}
