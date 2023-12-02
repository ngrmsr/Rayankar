using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Domain.Customers.Entities;
using Infrastucture.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Integration.Test
{
    public class CustomerController : ControllerBaseTest
    {
        private ICustomerRepository _customerRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _customerRepository = new CustomerRepository(GetContext());
        }

        [SetUp]
        public void SetUp()
        {
            StartDatabase();
            ResetDatabase();
        }

        [Theory]
        [TestCase("a", "a", "a@a.com", "1111", "98989898", "1999/09/09", HttpStatusCode.OK, 1)]
        public void Must_Add_Valid_Customer(string firstName, string lastName, string email, string bankAccountNumber, ulong phoneNumber, string dateOfBirth, HttpStatusCode code, int count)
        {
            var command = new CustomerCreateCommand
            {
                Firstname = firstName,
                Lastname = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                DateOfBirth = DateTime.Parse(dateOfBirth)
            };
            var obj = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
            var content = new ByteArrayContent(obj);
            var response = httpClient.PostAsync("/CreateCustomer", content).Result;
            response.StatusCode.Should().Be(code);
        }

        public void Must_Update_Valid_Customer()
        {
            var customer = CreateCustomer();
            var command = new CustomerUpdateCommand()
            {
                CustomerId = 1,
                Firstname = "a",
                Lastname = "a",
                Email = "a@a.com",
                PhoneNumber = 98788923,
                BankAccountNumber = "11111111111",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            var obj = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
            var content = new ByteArrayContent(obj);
            var response = httpClient.PutAsync("/PutCustomer", content).Result;
            _customerRepository.GetById(customer.Id).Firstname.Should().Be(command.Firstname);
        }

        public void Must_not_Update_Valid_Customer()
        {
            var Customer = CreateCustomer();
            var command = new CustomerUpdateCommand()
            {
                CustomerId = 10,
                Firstname = "a",
                Lastname = "a",
                Email = "a@a.com",
                PhoneNumber = 98788923,
                BankAccountNumber = "11111111111",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            var obj = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
            var content = new ByteArrayContent(obj);
            var response = httpClient.PutAsync("/PutCustomer", content).Result;
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private Customer CreateCustomer()
        {
            var CustomerRepository = new CustomerRepository(GetContext());
            var Customer = new Customer();
            CustomerRepository.Add(Customer);
            CustomerRepository.SaveChange();
            return Customer;
        }
    }
}
