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
        /// <summary>
        /// Retrieves orders in a NPC Station or player owned public structure.
        /// </summary>
        /// <param name="publicAuth">AuthDTO of a character with public structure access. If a private citadel id is provided,
        /// the character who added that citadel will be used.</param>
        /// <param name="structureId"></param>
        /// <param name="typeIds"></param>
        /// <returns></returns>
        public static async Task<Dictionary<int, List<MarketOrder>>> GetOrdersInStructure(AuthDTO publicAuth, long structureId, List<int> typeIds = null)
        {
            try
            {
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
        /// Retrieves orders from multiple structureIds.
        /// </summary>
        /// <param name="publicAuth">AuthDTO of a character with public structure access. If a private citadel id is provided,
        /// the character who added that citadel will be used.</param>
        /// <param name="structureIds"></param>
        /// <param name="typeIds"></param>
        /// <returns></returns>
        public static async Task<Dictionary<long, Dictionary<int, List<MarketOrder>>>> GetOrdersFromStructures(AuthDTO publicAuth, List<long> structureIds, List<long> typeIds = null)
        {
            try
            {
                var taskList = new List<Task>();

                var finalDict = new Dictionary<long, Dictionary<int, List<MarketOrder>>>();
                // Contains the list of regions to search and the structureIds relevant to the market search.
                var regionsDict = new Dictionary<int, List<(long, List<MarketOrder>)>>();

                var npcStations = new List<StaStations>();
                var privatePlayerStructures = new List<PlayerStructure>();
                var publicStructures = new List<Structure>();

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
                    if (StructureManager.TryGetPlayerStructure(structureId, out var structure))
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
                        publicStructures.Add(result.Model);
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
                        var localTaskList = new List<Task>();

                        var typeIdBag = new ConcurrentBag<long>();

                        // get relevant typeIds
                        var firstTypePage = await EsiData.EsiClient.Market.ListTypeIdsRelevantToMarketV1Async(region);

                        if (firstTypePage.MaxPages > 1)
                        {
                            for (var i = 2; i <= firstTypePage.MaxPages; i++)
                            {
                                var i1 = i;
                                localTaskList.Add(Task.Run(async () =>
                                {
                                    var result = await EsiData.EsiClient.Market.ListTypeIdsRelevantToMarketV1Async(region, i1);
                                    foreach (var typeId in result.Model)
                                    {
                                        typeIdBag.Add(typeId);
                                    }
                                }));
                            }
                        }

                        await Task.WhenAll(localTaskList);
                        localTaskList.Clear();
                        var relevantTypes = typeIdBag.ToList();

                        var typeToOrderDictionary = new Dictionary<long, List<MarketOrder>>();

                        // union types
                        if (typeIds != null)
                        {
                            relevantTypes = relevantTypes.Union(typeIds).ToList();
                        }

                        // Generate list of orders
                        foreach (var typeId in relevantTypes)
                        {
                            localTaskList.Add(Task.Run(async () =>
                            {
                                var orders = await GetOrdersInRegion(region, typeId);
                                typeToOrderDictionary.TryAdd(typeId, orders);
                            }));
                        }

                        await Task.WhenAll(localTaskList);
                        localTaskList.Clear();


                    }));

                    // filter by individual structureId

                    // add orders to structure

                    // if any are private structures, add those too.
                }

                await Task.WhenAll(taskList);

                return null;

                void AddToRegionsDict(int regionId, long structureId)
                {
                    if (regionsDict.TryGetValue(regionId, out var structsList))
                    {
                        structsList.Add((structureId, new List<MarketOrder>() { }));
                    }
                    else
                    {
                        regionsDict.Add(regionId, new List<(long, List<MarketOrder>)> () { (structureId, new List<MarketOrder>()) });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(PlayerStructure structure, List<int> typeIds = null)
        {
            var ordersHashSet = new HashSet<MarketOrder>();
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

            var firstResult = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structure.StructureId);
            var maxPages = firstResult.MaxPages;

            ordersHashSet.UnionWith(firstResult.Model);

            if (maxPages > 1)
            {
                for (var i = 2; i <= maxPages; i++)
                {
                    var i1 = i;
                    taskList.Add(Task.Run(async () =>
                    {
                        var result = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structure.StructureId, i1);
                        ordersHashSet.UnionWith(result.Model);
                    }));
                }
            }

            await Task.WhenAll(taskList);

            if (typeIds == null) return ordersHashSet.ToList();

            var hashTypeIds = new HashSet<int>(typeIds);
            var returnOrders = new List<MarketOrder>();
            

            try
            {
                ordersHashSet.RemoveWhere(o => o == null);

                foreach (var marketOrder in ordersHashSet.ToList())
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
    }
}