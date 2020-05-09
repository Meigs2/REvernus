namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvMarketGroupsConfiguration : IEntityTypeConfiguration<InvMarketGroups>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvMarketGroups> builder)
        {
            builder.HasKey(e => e.MarketGroupId);

            builder.ToTable("invMarketGroups");

            builder.Property(e => e.MarketGroupId)
                .HasColumnName("marketGroupID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(3000)");

            builder.Property(e => e.HasTypes)
                .HasColumnName("hasTypes")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.MarketGroupName)
                .HasColumnName("marketGroupName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.ParentGroupId).HasColumnName("parentGroupID");
        }
    }
}
