using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using Banking.Operation.Balance.Query.Domain.Balance.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Infra.Data.Balance.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IConfiguration _configuration;

        public BalanceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<BalanceDto> GetBalance(Guid clientId)
        {
            await using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string sql = $@"select
	                            sum(if(Type = 0, Value, -Value)) as Value
                            from
	                            Transactions
                            where
	                            ClientId = @CLIENT_ID";

            return await connection.QueryFirstOrDefaultAsync<BalanceDto>(sql: sql, new { CLIENT_ID = clientId });
        }
    }
}
