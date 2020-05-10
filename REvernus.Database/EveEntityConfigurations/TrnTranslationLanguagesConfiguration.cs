namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class TrnTranslationLanguagesConfiguration : IEntityTypeConfiguration<TrnTranslationLanguages>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<TrnTranslationLanguages> builder)
        {
            builder.HasKey(e => e.NumericLanguageId);

            builder.ToTable("trnTranslationLanguages");

            builder.Property(e => e.NumericLanguageId)
                .HasColumnName("numericLanguageID")
                .ValueGeneratedNever();

            builder.Property(e => e.LanguageId)
                .HasColumnName("languageID")
                .HasColumnType("VARCHAR(50)");

            builder.Property(e => e.LanguageName)
                .HasColumnName("languageName")
                .HasColumnType("VARCHAR(200)");
        }
    }
}
