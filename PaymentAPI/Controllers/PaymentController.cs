using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService) => _paymentService = paymentService;

        [HttpGet]
        public async Task<List<Account>> Get() => await _paymentService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Account>> Get(string cardNumber)
        {
            var account = await _paymentService.GetAsync(cardNumber);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> Post(Account account)
        {
            await _paymentService.CreateAsync(account);
            return CreatedAtAction(nameof(Post), account);
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(Account givenAccount, decimal amount)
        {
            var account = await _paymentService.GetAsync(givenAccount.CardNumber);
            if(account == null)
            {
                return NotFound();
            }
        }

    }
}
