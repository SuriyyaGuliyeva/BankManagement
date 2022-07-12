using AutoMapper;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using BankManagement.ResponseModels.ClientResponseModels;

namespace BankManagement.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientRequestModel, Client>();
            CreateMap<Client, CreateClientResponseModel>();
            CreateMap<EditClientRequestModel, Client>();
            CreateMap<Client, EditClientResponseModel>();
            CreateMap<Client, GetClientResponseModel>();
            CreateMap<Client, GetClientsResponseModel>();
        }
    }
}
