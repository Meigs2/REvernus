using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;
using REvernus.Models;
using REvernus.Utilities;
using REvernus.Views;

namespace REvernus.Core
{
    public static class CitadelManager
    {
        public static ObservableCollection<PlayerStructure> Structures = new ObservableCollection<PlayerStructure>();

        public static void Initialize()
        {
            LoadCitadelsFromDatabase();
        }

        public static void ShowCitadelManagementWindow()
        {
            var citadelManagerView = new CitadelManagerView();
            citadelManagerView.Show();
        }

        public static void LoadCitadelsFromDatabase()
        {
            Structures.Clear();
            using var connection = new SQLiteConnection(DatabaseManager.UserDataDbConnection);
            connection.Open();
            try
            {
                using var sqLiteCommand = new SQLiteCommand("SELECT * from structures", connection);

                using var reader = sqLiteCommand.ExecuteReader();
                while (reader.Read())
                {
                    var structure = new PlayerStructure
                    {
                        StructureId = (long)reader[0],
                        Name = (string)reader[1],
                        OwnerId = Convert.ToInt32((long)reader[2]),
                        SolarSystemId = Convert.ToInt32((long)reader[3]),
                        TypeId = Convert.ToInt32((long?)reader[4]),
                        AddedBy = (long?)reader[5],
                        AddedAt = (DateTime?)reader[6],
                        Enabled = Convert.ToBoolean((long?)reader[7])
                    };
                    Structures.Add(structure);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void InsertStructuresIntoDatabase(List<PlayerStructure> structures)
        {
            foreach (var structure in structures)
            {
                var connection = new SQLiteConnection(DatabaseManager.UserDataDbConnection);
                connection.Open();

                using var sqLiteCommand = new SQLiteCommand($"INSERT OR REPLACE INTO structures " +
                                                            $"(structureId, name, ownerId, solarSystemId, typeId, addedBy, addedAt, enabled) " +
                                                            $"VALUES (@structureId, @name, @ownerId, @solarSystemId, @typeId, @addedBy, @addedAt, @enabled)", connection);

                sqLiteCommand.Parameters.AddWithValue("@structureId", structure.StructureId);
                sqLiteCommand.Parameters.AddWithValue("@name", structure.Name);
                sqLiteCommand.Parameters.AddWithValue("@ownerId", structure.OwnerId);
                sqLiteCommand.Parameters.AddWithValue("@solarSystemId", structure.SolarSystemId);
                sqLiteCommand.Parameters.AddWithValue("@typeId", structure.TypeId);
                sqLiteCommand.Parameters.AddWithValue("@addedBy", structure.AddedBy);
                sqLiteCommand.Parameters.AddWithValue("@addedAt", DateTime.UtcNow);
                sqLiteCommand.Parameters.AddWithValue("@enabled", true);

                sqLiteCommand.CommandTimeout = 1;
                try
                {
                    sqLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                sqLiteCommand.Dispose();
                connection.Close();
            }
        }
    }
}
