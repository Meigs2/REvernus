namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivity
    {
        public long ActivityId { get; set; }
        public long? Time { get; set; }
        public long TypeId { get; set; }
    }
}