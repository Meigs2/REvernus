using System;
using System.Linq;
using EVEStandard;
using EVEStandard.Enumerations;
using REvernus.Models.UserDbModels;
using REvernus.Properties;

namespace REvernus.Core.ESI
{
    internal static class EsiData
    {
        public static EVEStandardAPI EsiClient
        {
            get
            {
                using var userContext = new UserContext();

                if (!userContext.DeveloperApplications.Any())
                {
                    return null;
                }

                var developerApplication = userContext.DeveloperApplications.Select(o => o).FirstOrDefault();
                if (developerApplication != null)
                    return new EVEStandardAPI(Strings.EsiData_EsiClient_UserAgent, DataSource.Tranquility,
                        TimeSpan.FromSeconds(30), developerApplication.CallbackUrl, developerApplication.ClientId, developerApplication.SecretKey);
                return null;
            }
        }
    }
}
