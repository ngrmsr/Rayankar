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
    public class UpdateCustomerCommandHandlerTest
    {
        private readonly Mock<ICustomerRepository> customerRepository;
        private readonly CustomerUpdateHandler updateCustomerCommandHandler;
        public UpdateCustomerCommandHandlerTest()
        {
            customerRepository = new Mock<ICustomerRepository>();
            updateCustomerCommandHandler = new CustomerUpdateHandler(customerRepository.Object);

        }

        [Fact]
        public void Should_Update_When_Command_Valid()
        {
            var updateCommand = new CustomerUpdateCommand()
            {
                CustomerId = 1,
                Firstname = "a",
                Lastname = "a",
                Email = "a@a.com",
                PhoneNumber = 98788923,
                BankAccountNumber = "11111111111",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            updateCustomerCommandHandler.Handel(updateCommand);
            customerRepository.Verify(r => r.Update(It.IsAny<Domain.Customers.Entities.Customer>()), Times.Once);
        }

        [Fact]
        public void Should_Update_When_Command_Invalid() //Not Exist
        {
            var updateCommand = new CustomerUpdateCommand()
            {
                CustomerId = 10,
                Firstname = "a",
                Lastname = "a",
                Email = "a@a.com",
                PhoneNumber = 98788923,
                BankAccountNumber = "11111111111",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            updateCustomerCommandHandler.Handel(updateCommand);
            customerRepository.Verify(r => r.Update(It.IsAny<Domain.Customers.Entities.Customer>()), Times.Never);
        }
    }
}
