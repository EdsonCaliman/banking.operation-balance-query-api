using Banking.Operation.Balance.Query.Domain.Balance.Parameters;
using Banking.Operation.Balance.Query.Domain.Balance.Repositories;
using Banking.Operation.Balance.Query.Infra.Data.Balance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.CrossCutting.Ioc.Modules
{
    [ExcludeFromCodeCoverageAttribute]
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var clientParameters = configuration.GetSection("ClientApi").Get<ClientApiParameters>();
            services.AddSingleton(clientParameters);

            services.AddScoped<IBalanceRepository, BalanceRepository>();
        }
    }
}
