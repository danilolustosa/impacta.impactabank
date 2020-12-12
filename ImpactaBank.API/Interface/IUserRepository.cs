using ImpactaBank.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface IUserRepository
    {
        User Get(User user);
    }
}
