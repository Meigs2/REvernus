namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class DgmExpressionsConfiguration : IEntityTypeConfiguration<DgmExpressions>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<DgmExpressions> builder)
        {
            builder.HasKey(e => e.ExpressionId);

            builder.ToTable("dgmExpressions");

            builder.Property(e => e.ExpressionId)
                .HasColumnName("expressionID")
                .ValueGeneratedNever();

            builder.Property(e => e.Arg1).HasColumnName("arg1");

            builder.Property(e => e.Arg2).HasColumnName("arg2");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.ExpressionAttributeId).HasColumnName("expressionAttributeID");

            builder.Property(e => e.ExpressionGroupId).HasColumnName("expressionGroupID");

            builder.Property(e => e.ExpressionName)
                .HasColumnName("expressionName")
                .HasColumnType("VARCHAR(500)");

            builder.Property(e => e.ExpressionTypeId).HasColumnName("expressionTypeID");

            builder.Property(e => e.ExpressionValue)
                .HasColumnName("expressionValue")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.OperandId).HasColumnName("operandID");
        }
    }
}
