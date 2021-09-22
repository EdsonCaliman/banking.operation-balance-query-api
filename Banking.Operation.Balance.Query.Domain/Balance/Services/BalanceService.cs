using Banking.Operation.Balance.Query.Domain.Abstractions.Exceptions;
using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using Banking.Operation.Balance.Query.Domain.Balance.Repositories;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Domain.Balance.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly IClientService _clientService;

        public BalanceService(IBalanceRepository balanceRepository, IClientService clientService)
        {
            _balanceRepository = balanceRepository;
            _clientService = clientService;
        }

        public async Task<ResponseBalanceDto> Get(Guid clientId)
        {
            await ValidateClient(clientId);

            var balanceDto = await _balanceRepository.GetBalance(clientId);

            return new ResponseBalanceDto(balanceDto);
        }

        private async Task ValidateClient(Guid clientid)
        {
            try
            {
                await _clientService.GetOne(clientid);
            }
            catch (Exception)
            {
                throw new BussinessException("Operation not performed", "Client not found");
            }            
        }
    }
}
