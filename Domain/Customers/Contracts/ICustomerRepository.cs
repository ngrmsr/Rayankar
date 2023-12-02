using Domain.Customers.Entities;
using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Delete(int id);
        Customer GetById(int id);
    }
}
