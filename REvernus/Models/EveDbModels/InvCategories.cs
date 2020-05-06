namespace REvernus.Models.EveDbModels
{
    public partial class InvCategories
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long? IconId { get; set; }
        public byte[] Published { get; set; }
    }
}
