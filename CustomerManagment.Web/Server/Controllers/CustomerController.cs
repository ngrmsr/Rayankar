using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Framework.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Web.Server.Helper;

namespace CustomerManagment.Web.Server.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICommandHandler<CustomerCreateCommand> _createCustomerCommandHandler;
        private readonly ICommandHandler<CustomerUpdateCommand> _updateCustomerCommandHandler;
        private readonly ICommandHandler<CustomerDeleteCommand> _deleteCustomerCommandHandler;
        private readonly ICustomerQuery _customerQueries;

        public CustomerController(ICommandHandler<CustomerCreateCommand> createCustomerCommandHandler,
            ICommandHandler<CustomerUpdateCommand> updateCustomerCommandHandler,
            ICommandHandler<CustomerDeleteCommand> deleteCustomerCommandHandler,
            ICustomerQuery customerQueries)
        {
            _createCustomerCommandHandler = createCustomerCommandHandler;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
            _deleteCustomerCommandHandler = deleteCustomerCommandHandler;
            _customerQueries = customerQueries;
        }

        [HttpGet]
        [Route("/GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _customerQueries.GetAllCustomers());
        }

        [HttpPost]
        [Route("/CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateCommand command)
        {
            if (!command.PhoneNumber.ToString().IsPhoneNumberValid())
            {
                throw new ArgumentException("Invalid phone number");
            }
            var result = _createCustomerCommandHandler.Handel(command);
            if (result.error.Count() == 0)
                return Ok(result);
            return BadRequest(result.error);
        }

        [HttpPut]
        [Route("/PutCustomer")]
        public async Task<IActionResult> PutCustomer(CustomerUpdateCommand command)
        {
            if (!command.PhoneNumber.ToString().IsPhoneNumberValid())
            {
                throw new ArgumentException("Invalid phone number");
            }
            var result = _updateCustomerCommandHandler.Handel(command);
            if (result.error.Count() == 0)
                return Ok(result);
            return BadRequest(result.error);
        }

        [HttpDelete]
        [Route("/DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(CustomerDeleteCommand command)
        {
            var result = _deleteCustomerCommandHandler.Handel(command);
            if (result.error.Count() == 0)
                return Ok(result);
            return BadRequest(result.error);
        }

        [HttpGet]
        [Route("/GetCustomerById")]
        public async Task<IActionResult> GetContact(int id)
        {
            return Ok(await _customerQueries.GetCustomerById(id));
        }
    }
}
