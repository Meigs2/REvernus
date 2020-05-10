namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvMetaGroups
    {
        public long MetaGroupId { get; set; }
        public string MetaGroupName { get; set; }
        public string Description { get; set; }
        public long? IconId { get; set; }
    }
}
