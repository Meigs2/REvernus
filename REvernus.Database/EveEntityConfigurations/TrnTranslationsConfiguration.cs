namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class TrnTranslationsConfiguration : IEntityTypeConfiguration<TrnTranslations>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<TrnTranslations> builder)
        {
            builder.HasKey(e => new { e.TcId, e.KeyId, e.LanguageId });

            builder.ToTable("trnTranslations");

            builder.Property(e => e.TcId).HasColumnName("tcID");

            builder.Property(e => e.KeyId).HasColumnName("keyID");

            builder.Property(e => e.LanguageId)
                .HasColumnName("languageID")
                .HasColumnType("VARCHAR(50)");

            builder.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("text");
        }
    }
}
