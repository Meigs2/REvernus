namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class DgmExpressions
    {
        public long? Arg1 { get; set; }
        public long? Arg2 { get; set; }
        public string Description { get; set; }
        public long? ExpressionAttributeId { get; set; }
        public long? ExpressionGroupId { get; set; }
        public long ExpressionId { get; set; }
        public string ExpressionName { get; set; }
        public long? ExpressionTypeId { get; set; }
        public string ExpressionValue { get; set; }
        public long? OperandId { get; set; }
    }
}