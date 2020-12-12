using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Model.Response;
using ImpactaBank.API.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public BaseResponse Insert(CustomerRequest request)
        {
            if (request.Name == String.Empty || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Name is empty" };

            if (request.Age == 0 || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Age is empty" };


            Customer customer = new Customer() 
            { 
                Age = request.Age,
                Name = request.Name
            };

            int id = _repository.Insert(customer);

            var result = Get(id);
            result.Message = "Customer was inserted.";
            result.StatusCode = StatusCodes.Status201Created;

            return result;
        }

        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            var result = _repository.Get(id);

            if (result == null)
                return new BaseResponse() { StatusCode = 404, Message = "Customer not found." };


            CustomerResponse response = new CustomerResponse() 
            { 
                Age = result.Age,
                Id = result.Id,
                Name = result.Name
            };


            response.Message = "OK";
            response.StatusCode = StatusCodes.Status200OK;
            
            return response;
        }

        public BaseResponse List()
        {
            var result = _repository.List();

            List<CustomerResponse> list = new List<CustomerResponse>();

            result.ForEach(c => {
                CustomerResponse response = new CustomerResponse()
                {
                    Age = c.Age,
                    Id = c.Id,
                    Name = c.Name
                };

                list.Add(response);
            });

            return new CustomerListResponse() { Customers = list, StatusCode = StatusCodes.Status200OK, Message = "OK" };
        }
    }
}
