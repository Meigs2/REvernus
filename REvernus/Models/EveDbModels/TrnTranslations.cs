using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class TrnTranslations
    {
        public long TcId { get; set; }
        public long KeyId { get; set; }
        public string LanguageId { get; set; }
        public string Text { get; set; }
    }
}
