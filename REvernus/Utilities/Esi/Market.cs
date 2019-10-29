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

namespace REvernus.Utilities.Esi
{
    public static class Market
    {
        /// <summary>
        /// Returns a list of 
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="typeId"></param>
        /// <param name="stationId"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static async Task<List<MarketOrder>> GetOrdersFromStation(AuthDTO auth, long typeId, long stationId, int range = 0)
        {

            if (StructureManager.TryGetNpcStation(stationId, out var station))
            {
                try
                {
                    var pageNum = 0;
                    var orders = new List<MarketOrder>();
                    do
                    {
                        var result = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(10000002, typeId, ++pageNum);
                        if (result.Model.Count == 0) break;
                        result.Model.RemoveAll(a => a.LocationId != stationId);
                        orders = orders.Union(result.Model).ToList();

                    } while (true);
                    return orders;
                }
                catch (Exception)
                {
                    return new List<MarketOrder>();
                }
            }

            if (StructureManager.TryGetPlayerStructure(stationId, out var playerStructure))
            {
                try
                {
                    var pageNum = 0;
                    var orders = new List<MarketOrder>();
                    do
                    {
                        var result = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(10000002, typeId, ++pageNum);
                        if (result.Model.Count == 0) break;
                        result.Model.RemoveAll(o => o.TypeId != typeId);
                        orders = orders.Union(result.Model).ToList();

                    } while (true);
                    return orders;
                }
                catch (Exception)
                {
                    return new List<MarketOrder>();
                }
            }

            return new List<MarketOrder>();
        }

        public static void GetMarketOrders(List<long> systemIds, List<long> itemIds)
        {
            // get regions orders are in for pubic orders

            // get structures orders are in for private orders

            // Get orders for public orders

            // Get orders in private citadels

            // build dictionary
        }

        public static void GetBestBuySell(List<MarketOrder> orderList, out MarketOrder bestBuyOrder, out MarketOrder bestSellOrder)
        {
            bestBuyOrder = new MarketOrder();
            bestSellOrder = new MarketOrder();

            var buyOrders = orderList.Where(i => i.IsBuyOrder).ToList();
            var sellOrders = orderList.Where(i => !i.IsBuyOrder).ToList();

            if (buyOrders.Count >= 1)
            {
                bestBuyOrder = buyOrders[0];
            }

            foreach (var marketOrder in buyOrders)
            {
                if (marketOrder.Price > bestBuyOrder.Price)
                {
                    bestBuyOrder = marketOrder;
                }
            }

            if (sellOrders.Count >= 1)
            {
                bestSellOrder = sellOrders[0];
            }

            foreach (var marketOrder in sellOrders)
            {
                if (marketOrder.Price < bestSellOrder.Price)
                {
                    bestSellOrder = marketOrder;
                }
            }

        }

        public static void GetStructureOrders(int typeId, long structureId)
        {
            // todo Implement player structure order browsing
        }
    }
}