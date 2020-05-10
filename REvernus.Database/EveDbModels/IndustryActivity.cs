using JetBrains.Annotations;

namespace REvernus.Database.EveDbModels
{
    [PublicAPI]
    public class IndustryActivity
    {
        public long TypeId { get; set; }
        public long ActivityId { get; set; }
        public long? Time { get; set; }
    }
}
