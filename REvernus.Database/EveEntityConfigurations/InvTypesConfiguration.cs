namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvTypesConfiguration : IEntityTypeConfiguration<InvTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvTypes> builder)
        {
            builder.HasKey(e => e.TypeId);

            builder.ToTable("invTypes");

            builder.HasIndex(e => e.GroupId)
                .HasName("ix_invTypes_groupID");

            builder.Property(e => e.TypeId)
                .HasColumnName("typeID")
                .ValueGeneratedNever();

            builder.Property(e => e.BasePrice)
                .HasColumnName("basePrice")
                .HasColumnType("DECIMAL(19, 4)");

            builder.Property(e => e.Capacity)
                .HasColumnName("capacity")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.GraphicId).HasColumnName("graphicID");

            builder.Property(e => e.GroupId).HasColumnName("groupID");

            builder.Property(e => e.IconId).HasColumnName("iconID");

            builder.Property(e => e.MarketGroupId).HasColumnName("marketGroupID");

            builder.Property(e => e.Mass)
                .HasColumnName("mass")
                .HasColumnType("FLOAT");

            builder.Property(e => e.PortionSize).HasColumnName("portionSize");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.RaceId).HasColumnName("raceID");

            builder.Property(e => e.SoundId).HasColumnName("soundID");

            builder.Property(e => e.TypeName)
                .HasColumnName("typeName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Volume)
                .HasColumnName("volume")
                .HasColumnType("FLOAT");
        }
    }
}
