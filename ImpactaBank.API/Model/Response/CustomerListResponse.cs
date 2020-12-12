using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model.Response
{
    public class CustomerListResponse : BaseResponse
    {
        public List<CustomerResponse> Customers { get; set; }
    }
}
