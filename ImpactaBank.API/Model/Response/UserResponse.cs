using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model.Response
{
    public class UserResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
