using REvernus.Database.Contexts;
using REvernus.Database.EveDbModels;
using REvernus.Database.UserDbModels;
using REvernus.Models;
using REvernus.Views;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            var context = new UserContext();
            var structures = context.AddedStructures.ToList();
            foreach (var dbStructure in structures)
            {
                var structure = new PlayerStructure
                {
                    StructureId = dbStructure.StructureId,
                    Name = dbStructure.Name,
                    OwnerId = dbStructure.OwnerId,
                    SolarSystemId = dbStructure.SolarSystemId,
                    TypeId = dbStructure.TypeId,
                    AddedBy = dbStructure.AddedBy,
                    AddedAt = dbStructure.AddedAt,
                    Enabled = dbStructure.Enabled,
                    IsPublic = dbStructure.IsPublic
                };
                Structures.Add(structure);
            }

            context.Dispose();
        }

        public static void InsertStructuresIntoDatabase(List<PlayerStructure> structures)
        {
            foreach (var playerStructure in structures)
            {
                var context = new UserContext();
                if (!context.AddedStructures.Any(o => o.StructureId == playerStructure.StructureId))
                    context.AddedStructures.Add(new AddedStructure
                    {
                        StructureId = playerStructure.StructureId,
                        Name = playerStructure.Name,
                        OwnerId = playerStructure.OwnerId,
                        SolarSystemId = playerStructure.SolarSystemId,
                        TypeId = playerStructure.TypeId.GetValueOrDefault(),
                        AddedBy = playerStructure.AddedBy.GetValueOrDefault(),
                        AddedAt = playerStructure.AddedAt.GetValueOrDefault(),
                        Enabled = playerStructure.Enabled.GetValueOrDefault(),
                        IsPublic = playerStructure.IsPublic
                    });

                context.SaveChanges();
                context.Dispose();
            }
        }

        public static void RemoveStructuresFromDatabase(IList structures)
        {
            var context = new UserContext();
            foreach (PlayerStructure structure in structures)
            {
                var a = context.AddedStructures.FirstOrDefault(s => s.StructureId == structure.StructureId);
                if (a != null) context.Remove(a);
            }

            context.SaveChanges();
            context.Dispose();
        }

        public static bool TryGetPlayerStructure(long structureId, out PlayerStructure playerStructure)
        {
            playerStructure = Structures.FirstOrDefault(s => s.StructureId == structureId);
            return playerStructure != null;
        }

        public static bool TryGetNpcStation(long stationId, out StaStations station)
        {
            station = null;
            using var db = new EveContext();
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

        public static string GetStructureName(long structureId)
        {
            // check for NPC station
            if (TryGetNpcStation(structureId, out var station)) return station.StationName;
            if (TryGetPlayerStructure(structureId, out var structure))
                return structure.Name;
            return "Unknown Structure";
        }
    }
}