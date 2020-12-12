using ImpactaBank.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Interface
{
    public interface ICustomerRepository
    {
        int Insert(Customer customer);
        Customer Get(int Id);
        List<Customer> List();
    }
}
