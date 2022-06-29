using BankManagement.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _bankContext;

        public BankController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        //get requests
        [HttpGet("/GetBanks")]
        public IActionResult GetBanks()
        {
            var banks = _bankContext.Banks;
            return Ok(banks);
        }
    }
}
