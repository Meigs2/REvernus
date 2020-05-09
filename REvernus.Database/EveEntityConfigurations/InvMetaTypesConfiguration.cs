namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvMetaTypesConfiguration : IEntityTypeConfiguration<InvMetaTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvMetaTypes> builder)
        {
            builder.HasKey(e => e.TypeId);

            builder.ToTable("invMetaTypes");

            builder.Property(e => e.TypeId)
                .HasColumnName("typeID")
                .ValueGeneratedNever();

            builder.Property(e => e.MetaGroupId).HasColumnName("metaGroupID");

            builder.Property(e => e.ParentTypeId).HasColumnName("parentTypeID");
        }
    }
}
