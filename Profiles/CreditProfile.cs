using AutoMapper;
using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;

namespace BankManagement.Profiles
{
    public class CreditProfile : Profile
    {
        public CreditProfile()
        {
            CreateMap<CreateCreditRequestModel, Credit>();
            CreateMap<Credit, CreateCreditResponseModel>();
        }
    }
}
