using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> AddClient(Client client)
        {
            return await _clientRepository.AddClient(client);
        }

        public async Task<bool> DeleteClient(int id)
        {
            Client client = await _clientRepository.GetClient(id);

            if (client is null)
            {
                return false;
            }

            await _clientRepository.DeleteClient(client);
            return true;
        }      

        public async Task<Client> EditClient(Client client)
        {
            return await _clientRepository.EditClient(client);
        }

        public async Task<Client> GetClient(int id)
        {
            Client client = await _clientRepository.GetClient(id);
            return client;           
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients = await _clientRepository.GetClients();
            return clients;
        }      
    }
}
