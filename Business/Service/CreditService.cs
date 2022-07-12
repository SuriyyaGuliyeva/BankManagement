using AutoMapper;
using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;
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
            return _mapper.Map<CreateCreditResponseModel>(credit);
        }

        public async Task<bool> DeleteCredit(int id)
        {
            Credit credit = await _creditRepository.GetCredit(id);
            await _creditRepository.DeleteCredit(credit);
            return true;
        }

        public async Task<Credit> EditCredit(Credit credit)
        {
            Credit cr = await _creditRepository.EditCredit(credit);
            return cr;
        }

        public async Task<Credit> GetCredit(int id)
        {
            Credit credit = await _creditRepository.GetCredit(id);
            return credit;
        }

        public async Task<List<Credit>> GetCredits()
        {
            var credits = await _creditRepository.GetCredits();
            return credits;
        }
    }
}
