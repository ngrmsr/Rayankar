using Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Contracts
{
    public interface ICustomerEventRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetCustomerById(int id);
    }
}
