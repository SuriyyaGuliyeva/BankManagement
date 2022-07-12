using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;
        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCredits()
        {
            var credits = await _creditService.GetCredits();
            return Ok(credits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCredit(int id)
        {
            var credit = await _creditService.GetCredit(id);
            return Ok(credit);
        }

        [HttpPost]
        public async Task<IActionResult> AddCredit([FromBody] CreateCreditRequestModel creditRequest)
        {
            CreateCreditResponseModel credit = await _creditService.AddCredit(creditRequest);
            return Ok(credit);
        }

        [HttpPut]
        public async Task<IActionResult> EditCredit([FromBody] Credit credit)
        {
            Credit cr = await _creditService.EditCredit(credit);
            return Ok(cr);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredit(int id)
        {
            bool result = await _creditService.DeleteCredit(id);
            return Ok(result);
        }
    }
}
