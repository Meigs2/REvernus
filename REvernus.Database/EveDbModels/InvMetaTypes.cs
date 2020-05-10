namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    public class InvMetaTypes
    {
        public long? MetaGroupId { get; set; }
        public long? ParentTypeId { get; set; }

        [PublicAPI]
        public long TypeId { get; set; }
    }
}