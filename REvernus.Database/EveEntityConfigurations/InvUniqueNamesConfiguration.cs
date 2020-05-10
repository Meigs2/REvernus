namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvUniqueNamesConfiguration : IEntityTypeConfiguration<InvUniqueNames>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvUniqueNames> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.ToTable("invUniqueNames");

            builder.HasIndex(e => e.ItemName)
                .HasName("ix_invUniqueNames_itemName")
                .IsUnique();

            builder.HasIndex(e => new { e.GroupId, e.ItemName })
                .HasName("invUniqueNames_IX_GroupName");

            builder.Property(e => e.ItemId)
                .HasColumnName("itemID")
                .ValueGeneratedNever();

            builder.Property(e => e.GroupId).HasColumnName("groupID");

            builder.Property(e => e.ItemName)
                .IsRequired()
                .HasColumnName("itemName")
                .HasColumnType("VARCHAR(200)");
        }
    }
}
