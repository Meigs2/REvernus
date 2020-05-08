namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class TranslationTablesConfiguration : IEntityTypeConfiguration<TranslationTables>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<TranslationTables> builder)
        {
            builder.HasKey(e => new { e.SourceTable, e.TranslatedKey });

            builder.ToTable("translationTables");

            builder.Property(e => e.SourceTable)
                .HasColumnName("sourceTable")
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.TranslatedKey)
                .HasColumnName("translatedKey")
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.DestinationTable)
                .HasColumnName("destinationTable")
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.TcGroupId).HasColumnName("tcGroupID");

            builder.Property(e => e.TcId).HasColumnName("tcID");
        }
    }
}
