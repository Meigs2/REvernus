using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVEStandard;
using EVEStandard.Enumerations;
using EVEStandard.Models.SSO;

namespace MEvernus.Core.ESI
{
    internal class EsiData
    {
        public static EVEStandardAPI EsiClient = new EVEStandardAPI(
            "REvernus",
            DataSource.Tranquility,
            TimeSpan.FromSeconds(30),
            "https://meigs2.github.io/ESICallback/",
            "ac5372b96ee24e158ff0915eb0c8c67e",
            null,
            SSOVersion.v2,
            SSOMode.Native
            );
    }
}
