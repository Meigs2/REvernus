namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class EveGraphics
    {
        public string Description { get; set; }
        public string GraphicFile { get; set; }
        public long GraphicId { get; set; }
        public string SofFactionName { get; set; }
        public string SofHullName { get; set; }
        public string SofRaceName { get; set; }
    }
}