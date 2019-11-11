using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace REvernus.Utilities
{
    public static class EveUniverse
    {
        public static bool TryGetRegionFromSystem(int systemId, out int regionId)
        {
            regionId = 0;

            var connection = new SQLiteConnection(DatabaseManager.ReadOnlyEveDbConnection);
            connection.Open();

            try
            {
                using var command = new SQLiteCommand("SELECT * FROM mapSolarSystems WHERE solarSystemId = @systemId",
                    connection);
                command.Parameters.AddWithValue("@systemId", systemId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    regionId = Convert.ToInt32(reader[0]);

                    connection.Close();

                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                connection.Close();
            }

            return false;
        }
    }
}
