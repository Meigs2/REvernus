using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Prism.Commands;
using REvernus.Core;
using REvernus.Models;
using REvernus.Utilities;
using REvernus.Views;

namespace REvernus.ViewModels
{
    public class CitadelManagerViewModel
    {
        public CitadelManagerViewModel()
        {

        }

        public DelegateCommand AddCitadelsCommand { get; set; } = new DelegateCommand(AddNewCitadels);
        private static void AddNewCitadels()
        {
            var citadelSearchWindow = new CitadelSearchWindow();
            citadelSearchWindow.ShowDialog();

            var selectedStructures = citadelSearchWindow.SelectedStructures;

            if (selectedStructures.Count <= 0) return;

            foreach (var structure in selectedStructures)
            {
                InsertStructureIntoDatabase(structure);
            }
        }

        private static void InsertStructureIntoDatabase(PlayerStructure structure)
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
            sqLiteCommand.Parameters.AddWithValue("@typeId",structure.TypeId);
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
