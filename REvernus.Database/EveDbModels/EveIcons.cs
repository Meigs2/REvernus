namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class EveIcons
    {
        public long IconId { get; set; }
        public string IconFile { get; set; }
        public string Description { get; set; }
    }
}
