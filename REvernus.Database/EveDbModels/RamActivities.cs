namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RamActivities
    {
        public long ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public string IconNo { get; set; }
        public byte[] Published { get; set; }
    }
}