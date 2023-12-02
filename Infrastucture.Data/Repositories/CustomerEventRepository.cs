using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Customers.Contracts;
using Domain.Customers.Entities;
using Infrastructure.Dapper.Contracts;

namespace Infrastucture.Data.Repositories
{
    public class CustomerEventRepository : ICustomerEventRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerEventRepository(IDbConnection dbConnection, IDapperContext dapperContext)
        {
            _dbConnection = dapperContext.CreateConnection();
        }
        public async Task<List<Customer>> GetAll()
            => (await _dbConnection.QueryAsync<Customer>("select * from [dbo].[Customer]")).ToList();

        public async Task<Customer> GetCustomerById(int id)
         => (await _dbConnection.QueryAsync<Customer>($"select * from [dbo].[Customer] WHERE Id={id}")).FirstOrDefault();
    }
}
