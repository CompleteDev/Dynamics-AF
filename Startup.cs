using DynamicsInfo.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

[assembly: FunctionsStartup(typeof(DynamicsInfo.Startup))]

namespace DynamicsInfo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IAccountDynamics, AccountDynamics>();

            //builder.Services.AddScoped<IDistributedCache, IDistributedCache>();

            //builder.Services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = Environment.GetEnvironmentVariable("Redis");
            //    options.InstanceName = "DynamicsInfo_";
            //});
        }
    }
}
