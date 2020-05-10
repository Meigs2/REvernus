namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class InvMetaTypes
    {
        public long? MetaGroupId { get; set; }
        public long? ParentTypeId { get; set; }
        public long TypeId { get; set; }
    }
}