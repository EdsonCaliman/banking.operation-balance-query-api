using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Domain.Balance.Services
{
    public interface IBalanceService
    {
        Task<ResponseBalanceDto> Get(Guid clientId);
    }
}
