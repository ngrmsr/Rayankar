using Domain.Customers.Contracts;
using Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Query
{
    public class CustomerQueryServices: ICustomerQuery
    {
        private readonly ICustomerEventRepository _customerEventRepository;

        public CustomerQueryServices(ICustomerEventRepository customerEventRepository)
        {
            _customerEventRepository = customerEventRepository;
        }

        public async Task<List<Customer>> GetAllCustomers() => await _customerEventRepository.GetAll();
        public async Task<Customer> GetCustomerById(int id) => await _customerEventRepository.GetCustomerById(id);
    }
}
