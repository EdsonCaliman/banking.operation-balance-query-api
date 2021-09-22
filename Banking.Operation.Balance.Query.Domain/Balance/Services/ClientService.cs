using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using Banking.Operation.Balance.Query.Domain.Balance.Parameters;
using Banking.Operation.Balance.Query.Domain.Balance.Services;
using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public class ClientService : IClientService
    {
        private const string _clientRelativeUrl = "/clients/{0}";
        private readonly ClientApiParameters _clientApiParameters;

        public ClientService(ClientApiParameters clientApiParameters)
        {
            _clientApiParameters = clientApiParameters;
        }

        public async Task<ClientDto> GetOne(Guid id)
        {
            var finalClientRelativeUrl = string.Format(_clientRelativeUrl, id);

            return await _clientApiParameters
                .Url
                .AppendPathSegment(finalClientRelativeUrl)
                .GetJsonAsync<ClientDto>();
        }
    }
}
