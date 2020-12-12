using ImpactaBank.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface IAccountRepository
    {
        public int Insert(Account account);
        public Account Get(int Id);
        public void Update(Account account);
        public void UpdateSituation(Account account);
    }
}
