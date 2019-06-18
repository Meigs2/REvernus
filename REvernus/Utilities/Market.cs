using EVEStandard.Models;
using REvernus.Core.ESI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REvernus.Utilities
{
    public static class Market
    {
        /// <summary>
        /// Returns a list of 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public static async Task<List<MarketOrder>> GetStationOrders(long typeId, long stationId)
        {
            var pageNum = 0;
            var orders = new List<MarketOrder>();
            do
            {
                var result = await EsiData.EsiClient.Market.ListOrdersInRegionV1Async(10000002, typeId, ++pageNum);
                result.Model.RemoveAll(a => a.LocationId != stationId);
                orders = orders.Union(result.Model).ToList();
                if (result.Model.Count == 0) break;

            } while (true);
            return orders;
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