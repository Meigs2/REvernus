namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvMetaGroupsConfiguration : IEntityTypeConfiguration<InvMetaGroups>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvMetaGroups> builder)
        {
            builder.HasKey(e => e.MetaGroupId);

            builder.ToTable("invMetaGroups");

            builder.Property(e => e.MetaGroupId)
                .HasColumnName("metaGroupID")
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.MetaGroupName)
                .HasColumnName("metaGroupName")
                .HasColumnType("VARCHAR(100)");
        }
    }
}
