using AutoMapper;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;

namespace BankManagement.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<CreateBankRequestModel, Bank>();//from->to
            CreateMap<Bank, CreateBankResponseModel>();
        }
    }
}
