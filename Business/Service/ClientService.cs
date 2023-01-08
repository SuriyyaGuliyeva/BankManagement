using AutoMapper;
using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using BankManagement.ResponseModels.ClientResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<CreateClientResponseModel> AddClient(CreateClientRequestModel clientRequest)
        {
            Client client = _mapper.Map<Client>(clientRequest);
            await _clientRepository.AddClient(client);

            return _mapper.Map<CreateClientResponseModel>(client);
        }

        public async Task<bool> DeleteClient(int id)
        {
            Client client = await _clientRepository.GetClient(id);            
            await _clientRepository.DeleteClient(client);

            return true;
        }

        public async Task<EditClientResponseModel> EditClient(EditClientRequestModel clientRequest)
        {
            Client client = await _clientRepository.GetClient(clientRequest.Id);
            client = _mapper.Map<Client>(clientRequest);
            client = await _clientRepository.EditClient(client);         

            return _mapper.Map<EditClientResponseModel>(client);
        }

        public async Task<GetClientResponseModel> GetClient(int id)
        {
            Client client = await _clientRepository.GetClient(id);

            return _mapper.Map<GetClientResponseModel>(client);
        }

        public async Task<List<GetClientsResponseModel>> GetClients()
        {
            List<Client> clients = await _clientRepository.GetClients();

            return _mapper.Map<List<GetClientsResponseModel>>(clients);
        }
    }
}
