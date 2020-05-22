using System;
using AzureFunctions.Autofac;
using AzureFunctions.Autofac.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ProductUsageCollector.Models;
using ProductUsageCollector.Services;

namespace ProductUsageCollector
{
    [DependencyInjectionConfig(typeof(AutoFacDIConfig))]
    public static class Function1
    {
        [FunctionName("GetSafetyUsageSummary")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log, [Inject] iSafetyUsageSummary _safetyUsageSummary, [Inject] iLocalProductData _localProductData)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        }
    }
}
