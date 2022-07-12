using AutoMapper;
using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using System;
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
                //return false;
                throw new Exception($"No Matching Bank with ID = {id} found");
            }

            await _bankRepository.DeleteBank(bank);
            return true;
        }

        public async Task<EditBankResponseModel> EditBank(EditBankRequestModel bankRequest)
        {
            Bank bankReq = _mapper.Map<Bank>(bankRequest);          

            Bank bank = await _bankRepository.EditBank(bankReq);

            if (bank is null)
            {
                throw new Exception($"No Matching Bank with ID = {bank.Id} found");
            }

            return _mapper.Map<EditBankResponseModel>(bank);
        }

        public async Task<GetBankResponseModel> GetBank(int id)
        {
            Bank bank = await _bankRepository.GetBank(id);

            if (bank is null)
            {
                //return BadRequest("Relevant Bank Id not found");
                throw new Exception($"No Matching Bank with ID = {id} found");
            }

            return _mapper.Map<GetBankResponseModel>(bank);
        }

        public async Task<List<GetBanksResponseModel>> GetBanks()
        {
            List<Bank> banks = await _bankRepository.GetBanks();
            return _mapper.Map<List<GetBanksResponseModel>>(banks);
        }
    }
}
