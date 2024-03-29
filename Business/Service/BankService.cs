﻿using AutoMapper;
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
            Bank bank = _mapper.Map<Bank>(bankRequest);
            await _bankRepository.AddBank(bank);
            return _mapper.Map<CreateBankResponseModel>(bank);
        }

        public async Task<bool> DeleteBank(int id)
        {
            Bank bank = await _bankRepository.GetBank(id);
            await _bankRepository.DeleteBank(bank);

            return true;
        }

        public async Task<EditBankResponseModel> EditBank(EditBankRequestModel bankRequest)
        {
            Bank bank = await _bankRepository.GetBank(bankRequest.Id);
            bank = _mapper.Map<Bank>(bankRequest);
            bank = await _bankRepository.EditBank(bank);

            return _mapper.Map<EditBankResponseModel>(bank);
        }

        public async Task<GetBankResponseModel> GetBank(int id)
        {
            Bank bank = await _bankRepository.GetBank(id);

            return _mapper.Map<GetBankResponseModel>(bank);
        }

        public async Task<IEnumerable<GetBanksResponseModel>> GetBanks()
        {
            var banks = await _bankRepository.GetBanks();
            return _mapper.Map<List<GetBanksResponseModel>>(banks);
        }

        //public async Task<List<GetBanksResponseModel>> GetBanks()
        //{
        //    List<Bank> banks = await _bankRepository.GetBanks();
        //    return _mapper.Map<List<GetBanksResponseModel>>(banks);
        //}
    }
}
