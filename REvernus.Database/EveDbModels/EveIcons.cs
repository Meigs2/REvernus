namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class EveIcons
    {
        public string Description { get; set; }
        public string IconFile { get; set; }
        public long IconId { get; set; }
    }
}