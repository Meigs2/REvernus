namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvGroupsConfiguration : IEntityTypeConfiguration<InvGroups>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvGroups> builder)
        {
            builder.HasKey(e => e.GroupId);

            builder.ToTable("invGroups");

            builder.HasIndex(e => e.CategoryId)
                .HasName("ix_invGroups_categoryID");

            builder.Property(e => e.GroupId)
                .HasColumnName("groupID")
                .ValueGeneratedNever();

            builder.Property(e => e.Anchorable)
                .HasColumnName("anchorable")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Anchored)
                .HasColumnName("anchored")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.CategoryId).HasColumnName("categoryID");

            builder.Property(e => e.FittableNonSingleton)
                .HasColumnName("fittableNonSingleton")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.GroupName)
                .HasColumnName("groupName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.UseBasePrice)
                .HasColumnName("useBasePrice")
                .HasColumnType("BOOLEAN");
        }
    }
}
