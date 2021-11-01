using Banking.Operation.Balance.Query.Domain.Balance.Services;
using Banking.Operation.Transaction.Domain.Transaction.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.CrossCutting.Ioc.Modules
{
    [ExcludeFromCodeCoverageAttribute]
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
