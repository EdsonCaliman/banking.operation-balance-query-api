using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Banking.Operation.Balance.Query.CrossCutting.Ioc.Modules;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.CrossCutting.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            DataModule.Register(services, configuration);
            services.Register();
            return services;
        }
    }
}
