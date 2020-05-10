namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvGroups
    {
        public byte[] Anchorable { get; set; }
        public byte[] Anchored { get; set; }
        public long? CategoryId { get; set; }
        public byte[] FittableNonSingleton { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public long? IconId { get; set; }
        public byte[] Published { get; set; }
        public byte[] UseBasePrice { get; set; }
    }
}