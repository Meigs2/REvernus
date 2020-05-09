namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class InvTypeReactionsConfiguration : IEntityTypeConfiguration<InvTypeReactions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<InvTypeReactions> builder)
        {
            builder.HasKey(e => new { e.ReactionTypeId, e.Input, e.TypeId });

            builder.ToTable("invTypeReactions");

            builder.Property(e => e.ReactionTypeId).HasColumnName("reactionTypeID");

            builder.Property(e => e.Input)
                .HasColumnName("input")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.Quantity).HasColumnName("quantity");
        }
    }
}
