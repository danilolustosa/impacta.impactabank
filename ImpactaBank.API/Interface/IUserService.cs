using ImpactaBank.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface IUserService
    {
        BaseResponse Login(string email, string password);
    }
}
