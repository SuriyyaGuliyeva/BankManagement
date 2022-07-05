using BankManagement.Business.IService;
using BankManagement.Entities;
using BankManagement.Infrastructure;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            var banks = await _bankService.GetBanks();
            return Ok(banks);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetBank(int id)
        {
            var bank = await _bankService.GetBank(id);

            if (bank is null)
            {
                return BadRequest("Relevant Bank Id not found");
            }

            return Ok(bank);
        }

        [HttpPost]
        public async Task<IActionResult> AddBank([FromBody] CreateBankRequestModel bankRequest)
        {
            CreateBankResponseModel response = await _bankService.AddBank(bankRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditBank([FromBody] Bank bank)
        {
            await _bankService.EditBank(bank);
            return Ok(bank); //NoContent();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            bool result = await _bankService.DeleteBank(id);
            if (!result)
            {
                return NotFound("Relevant Bank Id not found");
            }
            return Ok(result);
        }

        //[HttpGet("test")]
        //public IActionResult test()
        //{
        //    return Ok("bdu".TestConfig());
        //}
    }
}
