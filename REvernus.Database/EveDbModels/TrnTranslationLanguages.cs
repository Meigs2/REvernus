namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class TrnTranslationLanguages
    {
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public long NumericLanguageId { get; set; }
    }
}