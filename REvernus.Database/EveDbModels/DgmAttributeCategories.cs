namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class DgmAttributeCategories
    {
        public string CategoryDescription { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}