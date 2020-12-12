using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface ICustomerService
    {
        BaseResponse Insert(CustomerRequest request);
        BaseResponse Get(int id);
        BaseResponse List();

    }
}
