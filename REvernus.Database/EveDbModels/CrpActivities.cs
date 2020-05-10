namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class CrpActivities
    {
        public long ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
    }
}