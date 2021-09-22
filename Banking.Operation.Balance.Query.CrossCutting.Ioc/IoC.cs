using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Banking.Operation.Balance.Query.CrossCutting.Ioc.Modules;

namespace Banking.Operation.Balance.Query.CrossCutting.Ioc
{
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
