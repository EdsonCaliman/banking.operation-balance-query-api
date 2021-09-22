using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Domain.Balance.Repositories
{
    public interface IBalanceRepository
    {
        Task<BalanceDto> GetBalance(Guid clientId);
    }
}
