namespace REvernus.Database.EveDbModels
{
    public partial class RamActivities
    {
        public long ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string IconNo { get; set; }
        public string Description { get; set; }
        public byte[] Published { get; set; }
    }
}
