namespace Banking.Operation.Balance.Query.Domain.Balance.Dtos
{
    public class ResponseBalanceDto
    {
        public ResponseBalanceDto(BalanceDto balanceDto)
        {
            Value = balanceDto.Value;
        }
        public decimal Value { get; set; }
    }
}
