namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvVolumes
    {
        public long TypeId { get; set; }
        public long? Volume { get; set; }
    }
}
