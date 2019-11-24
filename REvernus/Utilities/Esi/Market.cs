using System;
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
                        taskList.Add(Task.Run(async () =>
                        {
                            var addedBy = CharacterManager.CharacterList.FirstOrDefault(c =>
                                c.CharacterDetails.CharacterId == structure.AddedBy);

                            if (addedBy != null)
                            {
                                var auth = new AuthDTO()
                                {
                                    AccessToken = addedBy.AccessTokenDetails,
                                    CharacterId = addedBy.CharacterDetails.CharacterId,
                                    Scopes = Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1
                                };

                                var orders = await GetOrdersInPrivateStructure(auth, structure, typeIds);
                                foreach (var marketOrder in orders)
                                {
                                    ordersList[marketOrder.TypeId].AddRange(orders.Where(o => o.TypeId == marketOrder.TypeId).ToList());
                                }
                            }
                        }));
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

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(AuthDTO auth, PlayerStructure structure, List<int> typeIds = null)
        {
            var ordersHashSet = new HashSet<MarketOrder>();
            var taskList = new List<Task>();

            var addedBy = CharacterManager.CharacterList.FirstOrDefault(c =>
                    c.CharacterDetails.CharacterId == structure.AddedBy);

            if (addedBy == null)
            {
                return null;
            }

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