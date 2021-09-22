using Banking.Operation.Balance.Query.Domain.Abstractions.Exceptions;
using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using Banking.Operation.Balance.Query.Domain.Balance.Repositories;
using Banking.Operation.Balance.Query.Domain.Balance.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Tests.Balance.Services
{
    public class BalanceServiceTest
    {
        private IBalanceService _balanceService;
        private Mock<IBalanceRepository> _balanceRepository;
        private Mock<IClientService> _clientService;

        [SetUp]
        public void SetUp()
        {
            _balanceRepository = new Mock<IBalanceRepository>();
            _clientService = new Mock<IClientService>();

            _balanceService = new BalanceService(_balanceRepository.Object, _clientService.Object);
        }

        [Test]
        public async Task ShouldReturnBalance()
        {
            var client = new ClientDto { Id = Guid.NewGuid(), Name = "Test", Email = "test@test.com" };
            _clientService.Setup(c => c.GetOne(client.Id)).Returns(Task.FromResult(client));
            var balance = new BalanceDto { Value = 2000 };
            _balanceRepository.Setup(c => c.GetBalance(client.Id)).Returns(Task.FromResult(balance));

            var balanceDto = await _balanceService.Get(client.Id);

            Assert.IsNotNull(balanceDto);
        }

        [Test]
        public void ShouldNotReturnBalanceWhenInvalidClient()
        {
            var clientId = Guid.NewGuid();

            Func<Task> action = async () => { await _balanceService.Get(clientId); };
            action.Should().ThrowAsync<BussinessException>();
        }
    }
}
