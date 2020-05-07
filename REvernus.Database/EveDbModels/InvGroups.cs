namespace REvernus.Database.EveDbModels
{
    public class InvGroups
    {
        public long GroupId { get; set; }
        public long? CategoryId { get; set; }
        public string GroupName { get; set; }
        public long? IconId { get; set; }
        public byte[] UseBasePrice { get; set; }
        public byte[] Anchored { get; set; }
        public byte[] Anchorable { get; set; }
        public byte[] FittableNonSingleton { get; set; }
        public byte[] Published { get; set; }
    }
}
