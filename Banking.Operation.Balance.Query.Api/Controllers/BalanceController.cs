using Banking.Operation.Balance.Query.Domain.Abstractions.Exceptions;
using Banking.Operation.Balance.Query.Domain.Abstractions.Messages;
using Banking.Operation.Balance.Query.Domain.Balance.Dtos;
using Banking.Operation.Balance.Query.Domain.Balance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Balance.Query.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/banking-operation/client/{clientid}/balance")]
    [ApiController]
    public class BalanceController : Controller
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IBalanceService _balanceService;

        public BalanceController(ILogger<BalanceController> logger, IBalanceService balanceService)
        {
            _logger = logger;
            _balanceService = balanceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBalanceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BussinessMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid clientid)
        {
            _logger.LogInformation("Receive Get...");

            try
            {
                var balance = await _balanceService.Get(clientid);

                if (balance is null)
                {
                    return NoContent();
                }

                return Ok(balance);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get exception: {ex}");
                throw;
            }
        }
    }
}
