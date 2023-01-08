using BankManagement.Business.IService;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClient(id);
            return Ok(client);
        }

        [HttpPost]       
        public async Task<IActionResult> AddClient([FromBody] CreateClientRequestModel clientRequest)
        {            
            CreateClientResponseModel createClientResponse = await _clientService.AddClient(clientRequest);            
            return Ok(createClientResponse);
        }

        [HttpPut]
        public async Task<IActionResult> EditClient([FromBody] EditClientRequestModel clientRequest)
        {
            EditClientResponseModel editClientResponse = await _clientService.EditClient(clientRequest);
            return Ok(editClientResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCLient(int id)
        {
            bool result = await _clientService.DeleteClient(id);          
            return Ok(result);
        }
    }
}
