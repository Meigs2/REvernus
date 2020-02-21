using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using EVEStandard.Models;

namespace REvernus.Utilities.Extensions
{
    public static class EveStandardExtensions
    {
        public static CharacterMarketOrder FromCsv(this CharacterMarketOrder order, string csvLine)
        {
            try
            {
                var values = csvLine.Split(',');

                order.OrderId = Convert.ToInt64(values[0]);
                order.TypeId = Convert.ToInt32(values[1]);
                order.RegionId = Convert.ToInt32(values[4]);
                order.LocationId = Convert.ToInt64(values[6]);
                order.Range = Convert.ToString(values[8]);
                order.IsBuyOrder = Convert.ToBoolean(values[9]);
                order.Price = Convert.ToDouble(values[10]);
                order.VolumeTotal = Convert.ToInt32(values[11]);
                order.VolumeRemain = Convert.ToInt32(Convert.ToDouble(values[12]));
                order.Issued = Convert.ToDateTime(values[13]);
                order.MinVolume = Convert.ToInt32(values[15]);
                order.Duration = Convert.ToInt32(values[17]);
                order.IsCorporation = Convert.ToBoolean(values[18]);
                order.Escrow = Convert.ToDouble(values[21]);

                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new CharacterMarketOrder();
            }
        }
    }
}
