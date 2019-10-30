using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Models;

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
        public static async Task<Dictionary<long, List<MarketOrder>>> GetOrdersInStructure(AuthDTO publicAuth, long structureId, List<long> typeIds = null)
        {
            try
            {
                var taskList = new List<Task>();

                var ordersList = new Dictionary<long, List<MarketOrder>>();

                // check for NPC station
                if (StructureManager.TryGetNpcStation(structureId, out var station))
                {
                    if (EveUniverse.TryGetRegionFromSystem(station.SystemId, out var regionId))
                    {
                        if (regionId != null)
                        {
                            if (typeIds != null)
                                foreach (var typeId in typeIds)
                                {
                                    taskList.Add(Task.Run(async () =>
                                    {
                                        var orders = await GetOrdersInRegion((int) regionId, typeId);
                                        ordersList.Add(typeId, orders.Where(o => o.LocationId == structureId).ToList());
                                    }));
                                }
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
                            if (regionId != null)
                            {
                                if (typeIds != null)
                                    foreach (var typeId in typeIds)
                                    {
                                        taskList.Add(Task.Run(async () =>
                                        {
                                            var orders = await GetOrdersInRegion((int)regionId, typeId);
                                            ordersList.Add(typeId, orders.Where(o => o.LocationId == structureId).ToList());
                                        }));
                                    }
                            }
                        }
                    }
                }

                // check if its a public structure

                // check if its a private structure

                await Task.WhenAll(taskList);

                return ordersList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            
            return ordersHashSet.ToList();
        }

        public static async Task<List<MarketOrder>> GetOrdersInPrivateStructure(long structureId, long? typeId = 0)
        {
            var ordersHashSet = new HashSet<MarketOrder>();
            var taskList = new List<Task>();

            if (StructureManager.TryGetPlayerStructure(structureId, out var playerStructure))
            {
                var addedBy = CharacterManager.CharacterList.FirstOrDefault(c =>
                    c.CharacterDetails.CharacterId == playerStructure.AddedBy);

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

                var firstResult = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structureId);
                var maxPages = firstResult.MaxPages;

                ordersHashSet.UnionWith(firstResult.Model);

                if (maxPages > 1)
                {
                    for (var i = 2; i <= maxPages; i++)
                    {
                        var i1 = i;
                        taskList.Add(Task.Run(async () =>
                        {
                            var result = await EsiData.EsiClient.Market.ListOrdersInStructureV1Async(auth, structureId, i1);
                            ordersHashSet.UnionWith(result.Model);
                        }));
                    }
                }

                await Task.WhenAll(taskList);

                return ordersHashSet.ToList();
            }

            return null;
        }

    }
}