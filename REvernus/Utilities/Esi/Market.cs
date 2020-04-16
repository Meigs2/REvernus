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
                    AccessToken = App.CharacterManager.SelectedCharacter.AccessTokenDetails,
                    CharacterId = App.CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
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

                var addedBy = App.CharacterManager.CharacterList.FirstOrDefault(c =>
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