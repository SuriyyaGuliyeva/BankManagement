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
            CreateMap<Credit, CreateCreditResponseModel>()
                .ForMember(dest =>
                dest.BankName,
                opt => opt.MapFrom(src => src.Bank.Name))
                .ForMember(dest =>
                dest.ClientName,
                opt => opt.MapFrom(src => src.Client.Name));
        }
    }
}
