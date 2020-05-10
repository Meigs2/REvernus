using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REvernus.Core;
using REvernus.Core.ESI;

namespace REvernus.Utilities
{
    using REvernus.Database.Contexts;

    public static class EveUniverse
    {
        public static bool TryGetRegionFromSystem(long? systemId, out int regionId)
        {
            regionId = 0;
            using var db = new EveContext();
            try
            {
                var solarSystem = db.MapSolarSystems.FirstOrDefault(o => o.SolarSystemId == systemId);
                if (solarSystem != null)
                {
                    regionId = Convert.ToInt32(solarSystem.RegionId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
