using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Balance.Query.Domain.Abstractions.Messages
{
    [ExcludeFromCodeCoverageAttribute]
    public class BussinessMessage
    {
        public BussinessMessage(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; private set; }
        public string Message { get; private set; }
    }
}
