using System;
using System.Collections.Concurrent;
using System.Data;
using System.Threading.Tasks;

namespace REvernus.Utilities.StaticData
{
    public class EveItems
    {
        public static ConcurrentDictionary<long, string> TypeIdToTypeNameDictionary { get; set; } = new ConcurrentDictionary<long, string>();

        public static string TypeIdToTypeName(long typeId)
        {
            return TypeIdToTypeNameDictionary[typeId];
        }

        /// <summary>
        /// Returns a DataTable containing the typeID and typeNames of all items currently on the market.
        /// </summary>
        /// <returns></returns>
        public static Task<DataTable> GetAllInventoryTypesAsync()
        {
            return DatabaseManager.QueryEveDbAsync("SELECT * FROM 'invTypes' WHERE marketGroupID IS NOT null AND published IS true");
        }

        public static async Task Initialize()
        {
            try
            {
                TypeIdToTypeNameDictionary.Clear();

                var types = await GetAllInventoryTypesAsync();
                foreach (DataRow typesRow in types.Rows)
                {
                    TypeIdToTypeNameDictionary.TryAdd((long)typesRow["typeID"], typesRow["typeName"].ToString());
                }
                types.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
