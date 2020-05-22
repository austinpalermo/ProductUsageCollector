using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureFunctions.Autofac.Configuration;

namespace ProductUsageCollector.Services
{
    class AutoFacDIConfig
    {
        public AutoFacDIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<SafetyUsageSummary>().As<iSafetyUsageSummary>();
                builder.RegisterType<LocalProductData>().As<iLocalProductData>().SingleInstance();
            }, functionName);
        }
    }
}
