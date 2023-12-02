using Application.Customers.CommandHandler;
using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test.Customer.CommandHandlers
{
    public class DeleteCustomerCommandHandlerTest
    {
        private readonly Mock<ICustomerRepository> customerRepository;
        private readonly CustomerDeleteHandler deleteCustomerCommandHandler;
        public DeleteCustomerCommandHandlerTest()
        {
            customerRepository = new Mock<ICustomerRepository>();
            deleteCustomerCommandHandler = new CustomerDeleteHandler(customerRepository.Object);

        }

        [Fact]
        public void Should_Delete_When_Command_Valid()
        {
            var deleteCommand = new CustomerDeleteCommand()
            {
                CustomerId = 1,
            };
            deleteCustomerCommandHandler.Handel(deleteCommand);
            customerRepository.Verify(r => r.Delete(It.IsAny<Domain.Customers.Entities.Customer>().Id), Times.Once);
        }

        [Fact]
        public void Should_Delete_When_Command_Invalid() //Not Exist
        {
            var deleteCommand = new CustomerDeleteCommand()
            {
                CustomerId = 10
            };
            deleteCustomerCommandHandler.Handel(deleteCommand);
            customerRepository.Verify(r => r.Delete(It.IsAny<Domain.Customers.Entities.Customer>().Id), Times.Never);
        }
    }
}
