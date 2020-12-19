using ImpactaBank.API.Domain;
using System;
using ImpactaBank.API.Util;
using ImpactaBank.API.Repository;
using Microsoft.AspNetCore.Http;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Model.Response;
using ImpactaBank.API.Interface;

namespace ImpactaBank.API.Service
{
    public class AccountService : IAccountService
    {
        IAccountRepository _repository;

        public AccountService(IAccountRepository repository) => _repository = repository;

        public BaseResponse Insert(AccountRequest request)
        {
            if (request.CustomerId == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Customer is empty" };

            if (request.Situation == String.Empty || request.Situation == null)
                return new BaseResponse() { StatusCode = 400, Message = "Situation is empty" };

            string tokenMd5 = request.CustomerId.ToString() + " - " + DateTime.Now.ToString();
            request.Hash = Util.Util.CreateMD5(tokenMd5);


            // Mapeando REQUEST x DOMAIN
            Account account = new Account() 
            { 
                CustomerId = request.CustomerId,
                Hash = request.Hash,
                Situation = request.Situation
            };


            int id = _repository.Insert(account);
            var result = Get(id);
            result.Message = "Account was created.";
            result.StatusCode = StatusCodes.Status201Created;
            return result;
        }

        public BaseResponse Update(int id, AccountRequest request)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            if (request.CustomerId == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Customer is empty" };

            if (request.Hash != null && request.Hash != String.Empty)
                return new BaseResponse() { StatusCode = 400, Message = "Hash is not empty" };

            if (request.Situation == null || request.Situation == String.Empty)
                return new BaseResponse() { StatusCode = 400, Message = "Situation is empty" };


            // Mapeando REQUEST x DOMAIN
            Account account = new Account()
            {
                Id = id,
                CustomerId = request.CustomerId,
                Situation = request.Situation
            };


            _repository.Update(account);
            var result = Get(id);
            result.Message = "Account was updated.";
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        public BaseResponse UpdateSituation(int id, AccountSituationRequest request)
        {
            if (request.Situation == String.Empty)
                return new BaseResponse() { StatusCode = 400, Message = "Situation is empty" };

            // Mapeando REQUEST x DOMAIN
            Account account = new Account()
            {
                Id = id,                
                Situation = request.Situation
            };

            _repository.UpdateSituation(account);
            var result = Get(id);
            result.Message = "Account was updated.";
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            var result = _repository.Get(id);

            AccountResponse response = new AccountResponse() 
            { 
                CustomerId = result.CustomerId,
                Hash = result.Hash,
                Id = result.Id,
                Situation = result.Situation
            };

            response.StatusCode = StatusCodes.Status200OK;
            response.Message = "OK";
            return response;
        }       
    }
}
