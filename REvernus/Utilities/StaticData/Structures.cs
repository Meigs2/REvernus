using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace REvernus.Utilities.StaticData
{
    public class Structures
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Dictionary<long, string> StructureDictionary { get; set; } = new Dictionary<long, string>();

        public static string GetStructureName(long structureId)
        {
            try
            {
                StructureDictionary.TryGetValue(structureId, out var locationName);
                return locationName ?? "Unknown Citadel";
            }
            catch (Exception e)
            {
                Log.Error(e);
                Console.WriteLine(e);
            }

            return string.Empty;
        }

        public static async Task Initialize()
        {
            try
            {
                StructureDictionary.Clear();
                var result = await DatabaseManager.QueryEveDbAsync("SELECT stationId, stationName FROM staStations");
                foreach (DataRow row in result.Rows)
                {
                    StructureDictionary.Add((long)row[0],(string)row[1]);
                }
                result.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
            }
        }

        // todo: add static method to add a structure to DB
    }
}