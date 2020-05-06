namespace REvernus.Models.EveDbModels
{
    public partial class DgmExpressions
    {
        public long ExpressionId { get; set; }
        public long? OperandId { get; set; }
        public long? Arg1 { get; set; }
        public long? Arg2 { get; set; }
        public string ExpressionValue { get; set; }
        public string Description { get; set; }
        public string ExpressionName { get; set; }
        public long? ExpressionTypeId { get; set; }
        public long? ExpressionGroupId { get; set; }
        public long? ExpressionAttributeId { get; set; }
    }
}
