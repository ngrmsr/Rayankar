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
    public class CustomerDeleteHandler: ICommandHandler<CustomerDeleteCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDeleteHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Result Handel(CustomerDeleteCommand command)
        {
            _customerRepository.Delete(command.CustomerId);
            return new Result(true, null);
            //Can Add Event In This Part Like Publish To RabbitMQ And CustomerDeleteEvent class will use in this part To notify the deletion of information
        }
    }
}
