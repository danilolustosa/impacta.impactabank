using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model.Request
{
    public class AccountRequest
    {
        public string Hash { get; set; }
        public int CustomerId { get; set; }
        public string Situation { get; set; }
    }
}
