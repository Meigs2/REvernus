﻿using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class RamActivities
    {
        public long ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string IconNo { get; set; }
        public string Description { get; set; }
        public byte[] Published { get; set; }
    }
}
