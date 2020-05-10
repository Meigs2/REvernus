﻿namespace REvernus.Database.EveDbModels
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class DgmAttributeTypes
    {
        public long AttributeId { get; set; }
        public string AttributeName { get; set; }
        public long? CategoryId { get; set; }
        public double? DefaultValue { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public byte[] HighIsGood { get; set; }
        public long? IconId { get; set; }
        public byte[] Published { get; set; }
        public byte[] Stackable { get; set; }
        public long? UnitId { get; set; }
    }
}