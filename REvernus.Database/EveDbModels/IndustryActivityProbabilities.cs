﻿namespace REvernus.Database.EveDbModels
{
    public class IndustryActivityProbabilities
    {
        public long? TypeId { get; set; }
        public long? ActivityId { get; set; }
        public long? ProductTypeId { get; set; }
        public byte[] Probability { get; set; }
    }
}