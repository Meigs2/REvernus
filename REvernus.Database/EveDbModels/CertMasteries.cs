namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CertMasteries
    {
        public long? TypeId { get; set; }
        public long? MasteryLevel { get; set; }
        public long? CertId { get; set; }
    }
}
