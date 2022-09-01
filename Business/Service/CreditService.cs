using AutoMapper;
using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.Service
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;
        private readonly IMapper _mapper;

        public CreditService(ICreditRepository creditRepository, IMapper mapper)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        public async Task<CreateCreditResponseModel> AddCredit(CreateCreditRequestModel creditRequest)
        {
            Credit creditReq = _mapper.Map<Credit>(creditRequest);
            var credit = await _creditRepository.AddCredit(creditReq);
            credit = await _creditRepository.GetCredit(credit.Id);

            return _mapper.Map<CreateCreditResponseModel>(credit);
        }

        public async Task<bool> DeleteCredit(int id)
        {
            Credit credit = await _creditRepository.GetCredit(id);           
            await _creditRepository.DeleteCredit(credit);

            return true;
        }

        public async Task<EditCreditResponseModel> EditCredit(EditCreditRequestModel creditRequest)
        {
            Credit credit = await _creditRepository.GetCredit(creditRequest.Id);
            credit = _mapper.Map<Credit>(creditRequest);
            credit = await _creditRepository.EditCredit(credit);

            return _mapper.Map<EditCreditResponseModel>(credit);
        }

        public async Task<GetCreditResponseModel> GetCredit(int id)
        {
            Credit credit = await _creditRepository.GetCredit(id);

            return _mapper.Map<GetCreditResponseModel>(credit);
        }

        public async Task<List<GetCreditsResponseModel>> GetCredits()
        {
            //with EF
            //List<Credit> credits = await _creditRepository.GetCredits();
            //var creditList = _mapper.Map<List<GetCreditsResponseModel>>(credits);

            //return creditList;

            //with Dapper
            return await _creditRepository.GetCreditsWithDapper();
        }
    }
}
