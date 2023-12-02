using Application.AutoMapper;
using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Framework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.CommandHandler
{
    public class CustomerCreateHandler : ICommandHandler<CustomerCreateCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreateHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Result Handel(CustomerCreateCommand command)
        {
            var customer = CustomerMapper.CommandToEntity(command);
            _customerRepository.Add(customer);
            return new Result(true,null);

            //Can Add Event In This Part Like Publish To RabbitMQ And CustomerCreateEvent class will use in this part To notify the addition of information
        }
    }
}
