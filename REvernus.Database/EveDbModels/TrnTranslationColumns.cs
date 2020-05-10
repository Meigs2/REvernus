namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class TrnTranslationColumns
    {
        public long? TcGroupId { get; set; }
        public long TcId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string MasterId { get; set; }
    }
}
