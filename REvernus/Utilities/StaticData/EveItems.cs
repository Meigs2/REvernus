namespace REvernus.Utilities.StaticData
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using REvernus.Database.Contexts;

    public class EveItems
    {
        public static ConcurrentDictionary<long, string> TypeIdToTypeNameDictionary { get; } =
            new ConcurrentDictionary<long, string>();

        public static void Initialize()
        {
            using var db = new EveContext();
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

        public static string TypeIdToTypeName(long typeId)
        {
            return TypeIdToTypeNameDictionary[typeId];
        }
    }
}