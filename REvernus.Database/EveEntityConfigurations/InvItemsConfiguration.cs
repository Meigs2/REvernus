namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvItemsConfiguration : IEntityTypeConfiguration<InvItems>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvItems> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.ToTable("invItems");

            builder.HasIndex(e => e.LocationId)
                .HasName("ix_invItems_locationID");

            builder.HasIndex(e => new { e.OwnerId, e.LocationId })
                .HasName("items_IX_OwnerLocation");

            builder.Property(e => e.ItemId)
                .HasColumnName("itemID")
                .ValueGeneratedNever();

            builder.Property(e => e.FlagId).HasColumnName("flagID");

            builder.Property(e => e.LocationId).HasColumnName("locationID");

            builder.Property(e => e.OwnerId).HasColumnName("ownerID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
