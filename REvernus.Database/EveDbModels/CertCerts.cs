namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CertCerts
    {
        public long CertId { get; set; }
        public string Description { get; set; }
        public long? GroupId { get; set; }
        public string Name { get; set; }
    }
}
