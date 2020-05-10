namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class StaOperationServices
    {
        public long OperationId { get; set; }
        public long ServiceId { get; set; }
    }
}