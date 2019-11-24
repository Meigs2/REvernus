using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class TranslationTables
    {
        public string SourceTable { get; set; }
        public string DestinationTable { get; set; }
        public string TranslatedKey { get; set; }
        public long? TcGroupId { get; set; }
        public long? TcId { get; set; }
    }
}
