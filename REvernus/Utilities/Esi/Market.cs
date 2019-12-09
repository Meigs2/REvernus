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
        public static async Task<Dictionary<long, List<MarketOrder>>> GetOrdersInStructure(long structureId, List<long> typeIds = null)
        {
            try
            {
                var publicAuth = new AuthDTO()
                {
                    AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };

                var taskList = new List<Task>();

                var ordersList = new Dictionary<long, List<MarketOrder>>();

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

        public static async Task<Dictionary<long, Dictionary<long, List<MarketOrder>>>> GetOrdersFromStructures(List<long> structureIds, List<long> typeIds = null)
        {
            using var handle = Status.GetNewStatusHandle();
            try
            {
                var publicAuth = new AuthDTO()
                {
                    AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };
                var taskList = new List<Task>();

                var finalDict = new ConcurrentDictionary<long, ConcurrentDictionary<long, List<MarketOrder>>>();
                foreach (var structureId in structureIds)
                {
                    finalDict.TryAdd(structureId, new ConcurrentDictionary<long, List<MarketOrder>>());
                }

                // Contains the list of regions to search and the structureIds relevant to the market search.
                var regionsDict = new Dictionary<int, List<long>>();

                var npcStations = new List<StaStations>();
                var privatePlayerStructures = new List<PlayerStructure>();
                var publicStructuresIds = new List<(long, Structure)>();

                // Generate list of regions
                foreach (var structureId in structureIds)
                {
                    if (StructureManager.TryGetNpcStation(structureId, out var station))
                    {
                        npcStations.Add(station);
                        if (EveUniverse.TryGetRegionFromSystem(station.SolarSystemId, out var regionId))
                        {
                            AddToRegionsDict(regionId, structureId);
                        }
                    }
                    else if (StructureManager.TryGetPlayerStructure(structureId, out var structure))
                    {
                        privatePlayerStructures.Add(structure);
                        if (EveUniverse.TryGetRegionFromSystem(structure.SolarSystemId, out var regionId))
                        {
                            AddToRegionsDict(regionId, structureId);
                        }
                    }
                    else
                    {
                        var result = await EsiData.EsiClient.Universe.GetStructureInfoV2Async(publicAuth, structureId);
                        if (result.RemainingErrors != 0) continue;
                        publicStructuresIds.Add((structureId, result.Model));
                        if (EveUniverse.TryGetRegionFromSystem(result.Model.SolarSystemId, out var regionId))
                        {
                            AddToRegionsDict(regionId, structureId);
                        }
                    }
                }

                // we now have a list of regions and structures to include. Get all types in region. 
                foreach (var region in regionsDict.Keys)
                {
                    taskList.Add(Task.Run(async () =>
                    {
                        using var innerHandle = Status.GetNewStatusHandle();
                        var localTaskList = new List<Task>();

                        var relevantTypes = typeIds;

                        var typeToOrderDictionary = new ConcurrentDictionary<long, List<MarketOrder>>();

                        // union types
                        if (typeIds != null)
                        {
                            relevantTypes = relevantTypes.Union(typeIds).ToList();
                        }

                        // Generate list of orders
                        if (relevantTypes != null)
                        {
                            foreach (var typeId in relevantTypes)
                            {
                                localTaskList.Add(Task.Run(async () =>
                                {
                                    using var handle = Status.GetNewStatusHandle();
                                    var orders = await GetOrdersInRegion(region, typeId);
                                    typeToOrderDictionary.TryAdd(typeId, orders);
                                }));
                            }

                            var privateStructuresInRegion =
                                privatePlayerStructures.Where(s => regionsDict[region].Contains(s.StructureId))
                                    .ToList();

                            // check if any of the listed structures are in our region, if so query those too
                            foreach (var playerStructure in privateStructuresInRegion)
                            {
                                localTaskList.Add(Task.Run(async () =>
                                {
                                    using var handle = Status.GetNewStatusHandle();
                                    var orders = await GetOrdersInPrivateStructure(playerStructure, relevantTypes);
                                    foreach (var typeId in relevantTypes)
                                    {
                                        var relevantOrders = orders.Where(o => o.TypeId == typeId).ToList();
                                        typeToOrderDictionary[typeId].AddRange(relevantOrders);
                                    }
                                }));
                            }
                        }

                        await Task.WhenAll(localTaskList);
                        localTaskList.Clear();

                        // Now we have all orders relevant to the structures in this region.
                        // Add to final dict by location.

                        foreach (var structureId in regionsDict[region])
                        {
                            foreach (var orderId in typeToOrderDictionary.Keys)
                            {
                                localTaskList.Add(Task.Run(() =>
                                {
                                    using var handle = Status.GetNewStatusHandle();
                                    var a = typeToOrderDictionary[orderId].Where(o => o.LocationId == structureId)
                                        .ToList();
                                    finalDict[structureId].TryAdd(orderId, a);
                                }));
                            }
                        }

                        await Task.WhenAll(localTaskList);
                        localTaskList.Clear();
                    }));
                }

                await Task.WhenAll(taskList);

                return finalDict.ToDictionary(x => x.Key, x => x.Value.ToDictionary(y => y.Key, y => y.Value));

                void AddToRegionsDict(int regionId, long structureId)
                {
                    if (regionsDict.TryGetValue(regionId, out var structsList))
                    {
                        structsList.Add(structureId);
                    }
                    else
                    {
                        regionsDict.Add(regionId, new List<long> {structureId});
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                handle.Dispose();
            }
        }

        public static async Task<List<MarketOrder>> GetOrdersInRegion(int region, long? typeId = null)
        {
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
                        var result = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(region, typeId, i1);
                        ordersHashSet.UnionWith(result.Model);
                    }));
                }
            }

            await Task.WhenAll(taskList);

            ordersHashSet.RemoveWhere(o => o == null);

            return ordersHashSet.ToList();
        }

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(PlayerStructure structure, List<long> typeIds = null)
        {
            try
            {
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