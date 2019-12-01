using EVEStandard.Models.API;
using REvernus.Core.ESI;
using REvernus.Models;
using REvernus.Models.EveDbModels;
using REvernus.Utilities;
using REvernus.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace REvernus.Core
{
    public static class StructureManager
    {
        public static ObservableCollection<PlayerStructure> Structures = new ObservableCollection<PlayerStructure>();

        public static void Initialize()
        {
            LoadStructuresFromDatabase();
        }

        public static void ShowStructureManagementWindow()
        {
            var structureManagerView = new StructureManagerView();
            structureManagerView.Show();
        }

        public static void LoadStructuresFromDatabase()
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
                    try
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
                            Enabled = Convert.ToBoolean((long?)reader[7]),
                            isPublic = Convert.ToBoolean((long?)reader[8])
                        };
                        Structures.Add(structure);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
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
                try
                {
                    using var sqLiteCommand = new SQLiteCommand($"INSERT OR REPLACE INTO structures " +
                                                                $"(structureId, name, ownerId, solarSystemId, typeId, addedBy, addedAt, enabled, isPublic) " +
                                                                $"VALUES (@structureId, @name, @ownerId, @solarSystemId, @typeId, @addedBy, @addedAt, @enabled, @isPublic)",
                        connection);

                    sqLiteCommand.Parameters.AddWithValue("@structureId", structure.StructureId);
                    sqLiteCommand.Parameters.AddWithValue("@name", structure.Name);
                    sqLiteCommand.Parameters.AddWithValue("@ownerId", structure.OwnerId);
                    sqLiteCommand.Parameters.AddWithValue("@solarSystemId", structure.SolarSystemId);
                    sqLiteCommand.Parameters.AddWithValue("@typeId", structure.TypeId);
                    sqLiteCommand.Parameters.AddWithValue("@addedBy", structure.AddedBy);
                    sqLiteCommand.Parameters.AddWithValue("@addedAt", DateTime.UtcNow);
                    sqLiteCommand.Parameters.AddWithValue("@enabled", true);
                    sqLiteCommand.Parameters.AddWithValue("@isPublic", structure.isPublic);

                    sqLiteCommand.CommandTimeout = 1;
                    sqLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    connection.Close();
                }
            }

            LoadStructuresFromDatabase();
        }

        public static void RemoveStructuresFromDatabase(IList structures)
        {
            var connection = new SQLiteConnection(DatabaseManager.UserDataDbConnection);
            connection.Open();

            try
            {
                // ReSharper disable once IdentifierTypo
                foreach (var structure in structures)
                {
                    using var command = new SQLiteCommand("DELETE FROM structures WHERE structureId = @structureId", connection);
                    command.Parameters.AddWithValue("@structureId", ((PlayerStructure)structure).StructureId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Ignored
            }
            finally
            {
                connection.Close();
            }

            LoadStructuresFromDatabase();
        }

        public static bool TryGetPlayerStructure(long structureId, out PlayerStructure playerStructure)
        {
            playerStructure = Structures.FirstOrDefault(s => s.StructureId == structureId);
            return playerStructure != null;
        }

        public static bool TryGetNpcStation(long stationId, out StaStations station)
        {
            station = null;
            using var db = new eveContext();
            try
            {
                station = db.StaStations.FirstOrDefault(o => o.StationId == stationId);
                return station != null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static async Task<string> GetStructureName(long structureId)
        {
            // check for NPC station
            if (StructureManager.TryGetNpcStation(structureId, out var station))
            {
                return station.StationName;
            }
            if (StructureManager.TryGetPlayerStructure(structureId, out var structure))
            {
                return structure.Name;
            }

            var result = await EsiData.EsiClient.Universe.GetStructureInfoV2Async(new AuthDTO()
            {
                AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                Scopes = EVEStandard.Enumerations.Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
            }, structureId);
            return result.Model.Name;
        }
    }
}
