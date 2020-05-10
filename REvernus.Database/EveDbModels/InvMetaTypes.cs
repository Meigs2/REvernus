namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    public class InvMetaTypes
    {
        [PublicAPI]
        public long TypeId { get; set; }
        public long? ParentTypeId { get; set; }
        public long? MetaGroupId { get; set; }
    }
}
