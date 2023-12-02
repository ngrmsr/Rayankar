using Application.AutoMapper;
using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Framework.Command;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.CommandHandler
{
    public class CustomerUpdateHandler : ICommandHandler<CustomerUpdateCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUpdateHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Result Handel(CustomerUpdateCommand command)
        {
            var customer = CustomerMapper.CommandToEntity(command);
            _customerRepository.Update(customer);
            return new Result(true,null);
            //Can Add Event In This Part Like Publish To RabbitMQ And CustomerUpdateEvent class will use in this part To notify information updates
        }
    }
}
