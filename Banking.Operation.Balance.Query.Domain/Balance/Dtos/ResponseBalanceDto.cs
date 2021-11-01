using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.Domain.Balance.Dtos
{
    [ExcludeFromCodeCoverageAttribute]
    public class ResponseBalanceDto
    {
        public ResponseBalanceDto(BalanceDto balanceDto)
        {
            Value = balanceDto.Value;
        }
        public decimal Value { get; set; }
    }
}
