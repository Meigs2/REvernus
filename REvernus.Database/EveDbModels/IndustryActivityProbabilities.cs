namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class IndustryActivityProbabilities
    {
        public long? ActivityId { get; set; }
        public byte[] Probability { get; set; }
        public long? ProductTypeId { get; set; }
        public long? TypeId { get; set; }
    }
}