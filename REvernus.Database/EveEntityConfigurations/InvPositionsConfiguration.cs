namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvPositionsConfiguration : IEntityTypeConfiguration<InvPositions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvPositions> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.ToTable("invPositions");

            builder.Property(e => e.ItemId)
                .HasColumnName("itemID")
                .ValueGeneratedNever();

            builder.Property(e => e.Pitch)
                .HasColumnName("pitch")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Roll)
                .HasColumnName("roll")
                .HasColumnType("FLOAT");

            builder.Property(e => e.X)
                .HasColumnName("x")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Y)
                .HasColumnName("y")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Yaw)
                .HasColumnName("yaw")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Z)
                .HasColumnName("z")
                .HasColumnType("FLOAT");
        }
    }
}
