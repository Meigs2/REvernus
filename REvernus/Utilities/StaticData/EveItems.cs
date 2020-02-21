using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using REvernus.Models.EveDbModels;

namespace REvernus.Utilities.StaticData
{
    public class EveItems
    {
        public static ConcurrentDictionary<long, string> TypeIdToTypeNameDictionary { get; set; } = new ConcurrentDictionary<long, string>();

        public static string TypeIdToTypeName(long typeId)
        {
            return TypeIdToTypeNameDictionary[typeId];
        }

        public static void Initialize()
        {
            using var db = new eveContext();
            try
            {
                var items = db.InvTypes
                    .Where(t => t.MarketGroupId != null && t.Published).ToList();

                foreach (var item in items)
                {
                    TypeIdToTypeNameDictionary.TryAdd(item.TypeId, item.TypeName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
