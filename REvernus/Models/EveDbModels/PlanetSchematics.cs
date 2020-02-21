using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class PlanetSchematics
    {
        public long SchematicId { get; set; }
        public string SchematicName { get; set; }
        public long? CycleTime { get; set; }
    }
}
