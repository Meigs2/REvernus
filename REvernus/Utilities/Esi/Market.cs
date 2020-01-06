using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Models;
using REvernus.Models.EveDbModels;
using Type = System.Type;

namespace REvernus.Utilities.Esi
{
    public static class Market
    {
        public static async Task<Dictionary<int, List<MarketOrder>>> GetOrdersInStructure(long structureId, List<int> typeIds = null)
        {
            try
            {
                using var a = Status.GetNewStatusHandle();
                var publicAuth = new AuthDTO()
                {
                    AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };

                var taskList = new List<Task>();

                var ordersList = new Dictionary<int, List<MarketOrder>>();

                if (typeIds != null)
                {
                    var typeHash = typeIds.ToHashSet();
                    foreach (var typeId in typeHash)
                    {
                        ordersList.Add(typeId, new List<MarketOrder>());
                    }
                }

                // check for NPC station
                if (StructureManager.TryGetNpcStation(structureId, out var station))
                {
                    if (EveUniverse.TryGetRegionFromSystem(station.SolarSystemId, out var regionId))
                    {
                        if (typeIds != null)
                            foreach (var typeId in typeIds)
                            {
                                taskList.Add(Task.Run(async () =>
                                {
                                    var orders = await GetOrdersInRegion(regionId, typeId);
                                    ordersList[typeId].AddRange(orders.Where(o => o.LocationId == structureId).ToList());
                                }));
                            }
                    }
                }
                else
                {
                    var result = await EsiData.EsiClient.Universe.GetStructureInfoV2Async(publicAuth, structureId);
                    if (result.RemainingErrors == 0)
                    {
                        if (EveUniverse.TryGetRegionFromSystem(result.Model.SolarSystemId, out var regionId))
                        {
                            if (typeIds != null)
                                foreach (var typeId in typeIds)
                                {
                                    taskList.Add(Task.Run(async () =>
                                    {
                                        var orders = await GetOrdersInRegion(regionId, typeId);
                                        ordersList[typeId].AddRange(orders.Where(o => o.LocationId == structureId).ToList());
                                    }));
                                }
                        }
                    }
                }
                if (StructureManager.TryGetPlayerStructure(structureId, out var structure))
                {
                    if (typeIds != null)
                    {
                        var orders = await GetOrdersInPrivateStructure(structure, typeIds);
                        foreach (var marketOrder in orders)
                        {
                            ordersList[marketOrder.TypeId].AddRange(orders.Where(o => o.TypeId == marketOrder.TypeId).ToList());
                        }
                    }
                }

                await Task.WhenAll(taskList);

                return ordersList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="structuresToQuery"></param>
        /// <returns></returns>
        public static async Task<Dictionary<long, Dictionary<int, List<MarketOrder>>>> GetOrdersFromStructures(List<(long structureId, List<int> types, int range)> structuresToQuery)
        {
            var taskList = new List<Task>();

            var privatePlayerStructures = new List<PlayerStructure>();
            var regionToStructuresToSearch = new Dictionary<int, List<long>>();
            var primaryStructureToRegionDictionary = new Dictionary<long, int>();
            var structuresToStructuresInRange = new Dictionary<long, List<long>>();

            // Generate dict for final output.
            var structureToRelevantOrders = new ConcurrentDictionary<long, Dictionary<int, List<MarketOrder>>>();
            foreach (var (structureId, _, _) in structuresToQuery)
            {
                structureToRelevantOrders.TryAdd(structureId, new Dictionary<int, List<MarketOrder>>());
            }

            // build dictionaries
            foreach (var structure in structuresToQuery)
            {
                if (StructureManager.TryGetNpcStation(structure.structureId, out var station) && station != null)
                {
                    if (EveUniverse.TryGetRegionFromSystem(station.SolarSystemId, out var regionId))
                    {
                        primaryStructureToRegionDictionary.TryAdd(structure.structureId, regionId);
                        AddToRegionsDict(regionId, structure.structureId);
                        if (structure.range >= 0 && station.SolarSystemId != null)
                        {
                            var systemId = (int) station.SolarSystemId; 
                            var structures = EveUniverse.GetStructuresInRange(systemId, structure.range);
                            foreach (var structureId in structures)
                            {
                                AddToRegionsDict(regionId, structureId);
                            }
                        }
                    }
                }
                else if (StructureManager.TryGetPlayerStructure(structure.structureId, out var playerStructure) && playerStructure != null)
                {
                    if (EveUniverse.TryGetRegionFromSystem(playerStructure.SolarSystemId, out var regionId))
                    {
                        privatePlayerStructures.Add(playerStructure);
                        primaryStructureToRegionDictionary.TryAdd(structure.structureId, regionId);
                        AddToRegionsDict(regionId, playerStructure.StructureId);
                        if (structure.range >= 0)
                        {
                            var systemId = playerStructure.SolarSystemId;
                            var structures = EveUniverse.GetStructuresInRange(systemId, structure.range);
                            foreach (var structureId in structures)
                            {
                                AddToRegionsDict(regionId, structureId);
                            }
                        }
                    }
                }
                else
                {
                    var result = await EsiData.EsiClient.Universe.GetStructureInfoV2Async(CharacterManager.PublicAuthDto, structure.structureId);
                    if (result.RemainingErrors != 0) continue;
                    if (EveUniverse.TryGetRegionFromSystem(result.Model.SolarSystemId, out var regionId))
                    {
                        primaryStructureToRegionDictionary.TryAdd(structure.structureId, regionId);
                        AddToRegionsDict(regionId, structure.structureId);
                        if (structure.range >= 0)
                        {
                            var systemId = result.Model.SolarSystemId;
                            var structures = EveUniverse.GetStructuresInRange(systemId, structure.range);
                            foreach (var structureId in structures)
                            {
                                AddToRegionsDict(regionId, structureId);
                            }
                        }
                    }
                }
            }

            foreach (var (structureId, _, range) in structuresToQuery)
            {
                var a = await EveUniverse.GetStructuresInRange(structureId, range);
                structuresToStructuresInRange.TryAdd(structureId, a);
            }

            var uniqueDict = new Dictionary<int, List<long>>(regionToStructuresToSearch);
            foreach (var regionKeyValue in regionToStructuresToSearch)
            {
                uniqueDict[regionKeyValue.Key] = regionToStructuresToSearch[regionKeyValue.Key].Distinct().ToList();
            }
            regionToStructuresToSearch = uniqueDict;

            foreach (var regionKeyValue in regionToStructuresToSearch)
            {
                taskList.Add(Task.Run(async () =>
                {
                    var localTaskList = new List<Task>();

                    var primaryStructuresInCurrentRegion =
                        primaryStructureToRegionDictionary.Where(s => s.Value == regionKeyValue.Key).Select(s => s.Key).ToList();

                    var privateStructuresInRegion =
                        privatePlayerStructures.Where(s => primaryStructuresInCurrentRegion.Contains(s.StructureId)).ToList();

                    var typesInRegion =
                        structuresToQuery.Where(s => primaryStructuresInCurrentRegion.Contains(s.structureId)).ToList().SelectMany(s => s.types).ToHashSet();

                    var orders = new ConcurrentDictionary<int, ConcurrentBag<MarketOrder>>();
                    foreach (var type in typesInRegion)
                    {
                        orders.TryAdd(type, new ConcurrentBag<MarketOrder>());
                    }

                    // Get and add types for region
                    foreach (var typeId in typesInRegion)
                    {
                        localTaskList.Add(Task.Run(async () =>
                        {
                            var result = await GetOrdersInRegion(regionKeyValue.Key, typeId);
                            foreach (var marketOrder in result)
                            {
                                if (orders[typeId].Where(o => o.OrderId == marketOrder.OrderId).ToList().Count == 0)
                                {
                                    orders[typeId].Add(marketOrder);
                                }
                            }
                        }));
                    }

                    // Get and add types from private structure
                    foreach (var privateStructure in privateStructuresInRegion)
                    {
                        localTaskList.Add(Task.Run(async () =>
                        {
                            var result = await Market.GetOrdersInPrivateStructure(privateStructure, typesInRegion.ToList());
                            var groupsOfOrders = result.OrderBy(o => o.TypeId).GroupBy(o => o.TypeId).ToDictionary(s => s.Key, s => s.ToList());
                            foreach (var groupsOfOrder in groupsOfOrders)
                            {
                                foreach (var marketOrder in groupsOfOrder.Value)
                                {
                                    if (orders[groupsOfOrder.Key].Where(o => o.OrderId == marketOrder.OrderId).ToList().Count == 0)
                                    {
                                        orders[groupsOfOrder.Key].Add(marketOrder);
                                    }
                                }
                            }
                        }));
                    }

                    await Task.WhenAll(localTaskList);

                    foreach (var primaryStructureId in primaryStructuresInCurrentRegion)
                    {
                        var relevantStructures = structuresToStructuresInRange[primaryStructureId];
                        var types = structuresToQuery.First(s => s.structureId == primaryStructureId).types;

                        foreach (var relevantStructure in relevantStructures)
                        {
                            foreach (var type in types)
                            {
                                if (structuresToStructuresInRange.ContainsKey(relevantStructure))
                                {
                                    var ordersInRangedStructures = orders[type].Where(o =>
                                        structuresToStructuresInRange[relevantStructure].Any(s => o.LocationId == s)).ToList();
                                    structureToRelevantOrders[relevantStructure].Add(type, ordersInRangedStructures);
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                }));
            }

            await Task.WhenAll(taskList);

            return structureToRelevantOrders.ToDictionary(s => s.Key, s => s.Value);

            void AddToRegionsDict(int regionId, long structureId)
            {
                if (regionToStructuresToSearch.TryGetValue(regionId, out var structsList))
                {
                    structsList.Add(structureId);
                }
                else
                {
                    regionToStructuresToSearch.Add(regionId, new List<long> { structureId });
                }
            }
        }

        public static async Task<List<MarketOrder>> GetOrdersInRegion(int region, long? typeId = null)
        {
            using var a = Status.GetNewStatusHandle();
            var ordersHashSet = new HashSet<MarketOrder>();
            var taskList = new List<Task>();

            var firstResult = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(region, typeId);
            var maxPages = firstResult.MaxPages;

            ordersHashSet.UnionWith(firstResult.Model);

            if (maxPages > 1)   
            {
                for (var i = 2; i <= maxPages; i++)
                {
                    var i1 = i;
                    taskList.Add(Task.Run(async () =>
                    {
                        using var a1 = Status.GetNewStatusHandle();
                        var result = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(region, typeId, i1);
                        ordersHashSet.UnionWith(result.Model);
                    }));
                }
            }

            await Task.WhenAll(taskList);

            ordersHashSet.RemoveWhere(o => o == null);

            return ordersHashSet.ToList();
        }

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(PlayerStructure structure, List<int> typeIds)
        {
            return await GetOrdersInPrivateStructure(structure, typeIds.ConvertAll(i => (long) i));
        }

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(PlayerStructure structure, List<long> typeIds = null)
        {
            try
            {
                using var a = Status.GetNewStatusHandle();
                var ordersHashSet = new ConcurrentBag<MarketOrder>();
                var taskList = new List<Task>();

                var addedBy = CharacterManager.CharacterList.FirstOrDefault(c =>
                    c.CharacterDetails.CharacterId == structure.AddedBy);

                if (addedBy == null)
                {
                    return null;
                }

                var auth = new AuthDTO()
                {
                    AccessToken = addedBy.AccessTokenDetails,
                    CharacterId = addedBy.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1
                };

                try
                {
                    var firstResult = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structure.StructureId);
                    var maxPages = firstResult.MaxPages;

                    foreach (var marketOrder in firstResult.Model)
                    {
                        ordersHashSet.Add(marketOrder);
                    }

                    if (maxPages > 1)
                    {
                        for (var i = 2; i <= maxPages; i++)
                        {
                            var i1 = i;
                            taskList.Add(Task.Run(async () =>
                            {
                                using var a1 = Status.GetNewStatusHandle();
                                try
                                {
                                    var result = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structure.StructureId, i1);
                                    foreach (var marketOrder in result.Model)
                                    {
                                        ordersHashSet.Add(marketOrder);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                await Task.WhenAll(taskList);

                if (typeIds == null) return ordersHashSet.ToList();

                var hashTypeIds = new HashSet<long>(typeIds);
                var returnOrders = new List<MarketOrder>();
                
                try
                {
                    var orders = ordersHashSet.ToList();
                    orders.RemoveAll(o => o == null);

                    foreach (var marketOrder in orders)
                    {
                        try
                        {
                            if (hashTypeIds.Contains(marketOrder.TypeId))
                            {
                                returnOrders.Add(marketOrder);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }

                    return returnOrders;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}