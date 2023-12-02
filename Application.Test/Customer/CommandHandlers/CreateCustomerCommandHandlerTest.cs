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
    public class CreateCustomerCommandHandlerTest
    {
        private readonly Mock<ICustomerRepository> customerRepository;
        private readonly CustomerCreateHandler createCustomerCommandHandler;
        public CreateCustomerCommandHandlerTest()
        {
            customerRepository = new Mock<ICustomerRepository>();
            createCustomerCommandHandler = new CustomerCreateHandler(customerRepository.Object);

        }

        [Fact]
        public void Should_Create_When_Command_Valid()
        {
            var createCommand = new CustomerCreateCommand()
            {
                Firstname="a",
                Lastname="a",
                Email="a@a.com",
                PhoneNumber=98788923,
                BankAccountNumber="11111111111",
                DateOfBirth=DateTime.Now.AddYears(-20)
            };
            createCustomerCommandHandler.Handel(createCommand);
            customerRepository.Verify(r => r.Add(It.IsAny<Domain.Customers.Entities.Customer>()), Times.Once);
        }

        [Fact]
        public void Should_Create_When_Command_Invalid()
        {
            var createCommand = new CustomerCreateCommand()
            {
                Email = "a@a.com",
                PhoneNumber = 98788923,
                BankAccountNumber = "11111111111",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            createCustomerCommandHandler.Handel(createCommand);
            customerRepository.Verify(r => r.Add(It.IsAny<Domain.Customers.Entities.Customer>()), Times.Never);
        }
    }
}
