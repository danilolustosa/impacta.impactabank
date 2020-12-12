using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface IAccountService
    {
        BaseResponse Insert(AccountRequest request);
        BaseResponse Update(int id, AccountRequest request);
        BaseResponse UpdateSituation(int id, AccountSituationRequest request);
        BaseResponse Get(int id);
    }
}
