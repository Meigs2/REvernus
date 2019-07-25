using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
               var result = DatabaseManager.QueryEveDb(
                    $"SELECT stationName FROM staStations WHERE stationId = {structureId}", new SQLiteConnection(DatabaseManager.ReadOnlyEveDbConnection));
               if (result.Rows.Count == 0)
               {
                   return "Unknown Citadel";
               }
               else
               {
                   return (string) result.Rows[0][0];
               }
            }
            catch (Exception e)
            {
                Log.Error(e);
                Console.WriteLine(e);
            }

            return string.Empty;
        }

        // todo: add static method to add a structure to DB
    }
}