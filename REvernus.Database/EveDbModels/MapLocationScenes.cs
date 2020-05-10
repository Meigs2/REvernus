namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class MapLocationScenes
    {
        public long LocationId { get; set; }
        public long? GraphicId { get; set; }
    }
}
