using EVEStandard;
using EVEStandard.Enumerations;
using EVEStandard.Models.SSO;
using System;

namespace REvernus.Core.ESI
{
    internal class EsiData
    {
        public static string LocalUri = "https://meigs2.github.io/ESICallback/";

        public static EVEStandardAPI EsiClient = new EVEStandardAPI(
            "REvernus",
            DataSource.Tranquility,
            TimeSpan.FromSeconds(30),
            LocalUri,
            "ac5372b96ee24e158ff0915eb0c8c67e",
            null,
            SSOVersion.v2,
            SSOMode.Native
            );
    }
}
