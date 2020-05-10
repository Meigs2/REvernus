namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class TrnTranslations
    {
        public long KeyId { get; set; }
        public string LanguageId { get; set; }
        public long TcId { get; set; }
        public string Text { get; set; }
    }
}