using AutoMapper;
using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public BankService(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<CreateBankResponseModel> AddBank(CreateBankRequestModel bankRequest)
        {
            Bank bank = _mapper.Map<Bank>(bankRequest);//request model entity modele cevrilir
            await _bankRepository.AddBank(bank);//entity modeli insert edir
            return _mapper.Map<CreateBankResponseModel>(bank);//entity modeli response modele cevirir
        }

        public async Task<bool> DeleteBank(int id)
        {
            Bank bank = await _bankRepository.GetBank(id);
            if (bank is null)
            {
                return false;
            }
            await _bankRepository.DeleteBank(bank);
            return true;
        }

        public async Task<Bank> EditBank(Bank bank)
        {
            return await _bankRepository.EditBank(bank);
        }

        public async Task<Bank> GetBank(int id)
        {
            return await _bankRepository.GetBank(id);
        }

        public async Task<List<Bank>> GetBanks()
        {
            return await _bankRepository.GetBanks();
        }
    }
}
