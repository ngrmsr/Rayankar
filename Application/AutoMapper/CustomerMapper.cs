using AutoMapper;
using Domain.Customers.Commands;
using Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public static class CustomerMapper
    {
        public static Customer CommandToEntity(CustomerCreateCommand createCustomerCommand)
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<CustomerCreateCommand, Customer>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Customer>(createCustomerCommand);
        }

        public static Customer CommandToEntity(CustomerUpdateCommand updateCustomerCommand)
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<CustomerUpdateCommand, Customer>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Customer>(updateCustomerCommand);
        }
    }
}
