using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.Domain.Balance.Dtos
{
    [ExcludeFromCodeCoverageAttribute]
    public class BalanceDto
    {
        public decimal Value { get; set; }
    }
}
