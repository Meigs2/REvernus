namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class TrnTranslationColumnsConfiguration : IEntityTypeConfiguration<TrnTranslationColumns>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<TrnTranslationColumns> builder)
        {
            builder.HasKey(e => e.TcId);

            builder.ToTable("trnTranslationColumns");

            builder.Property(e => e.TcId)
                .HasColumnName("tcID")
                .ValueGeneratedNever();

            builder.Property(e => e.ColumnName)
                .IsRequired()
                .HasColumnName("columnName")
                .HasColumnType("VARCHAR(128)");

            builder.Property(e => e.MasterId)
                .HasColumnName("masterID")
                .HasColumnType("VARCHAR(128)");

            builder.Property(e => e.TableName)
                .IsRequired()
                .HasColumnName("tableName")
                .HasColumnType("VARCHAR(256)");

            builder.Property(e => e.TcGroupId).HasColumnName("tcGroupID");
        }
    }
}
