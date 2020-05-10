namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapLocationScenes
    {
        public long? GraphicId { get; set; }
        public long LocationId { get; set; }
    }
}