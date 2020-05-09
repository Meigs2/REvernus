namespace REvernus.Database.EveDbModels
{
    public class StaOperations
    {
        public long? ActivityId { get; set; }
        public long OperationId { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
        public long? Fringe { get; set; }
        public long? Corridor { get; set; }
        public long? Hub { get; set; }
        public long? Border { get; set; }
        public long? Ratio { get; set; }
        public long? CaldariStationTypeId { get; set; }
        public long? MinmatarStationTypeId { get; set; }
        public long? AmarrStationTypeId { get; set; }
        public long? GallenteStationTypeId { get; set; }
        public long? JoveStationTypeId { get; set; }
    }
}
