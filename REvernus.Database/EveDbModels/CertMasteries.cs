namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CertMasteries
    {
        public long? CertId { get; set; }
        public long? MasteryLevel { get; set; }
        public long? TypeId { get; set; }
    }
}