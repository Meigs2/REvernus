namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class TranslationTables
    {
        public string SourceTable { get; set; }
        public string DestinationTable { get; set; }
        public string TranslatedKey { get; set; }
        public long? TcGroupId { get; set; }
        public long? TcId { get; set; }
    }
}
