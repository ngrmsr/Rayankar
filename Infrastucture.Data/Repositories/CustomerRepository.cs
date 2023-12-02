using Infrastucture.Data.Repositories.Common;
using Domain.Customers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Customers.Entities;
using Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected readonly Context DbContext;
        public CustomerRepository(Context dbContext)
        : base(dbContext)
        {
            DbContext = dbContext;
        }
        public DbSet<Customer> Customers { get; }
        public void Delete(int id)
        {
            var entity = context.Customers.FirstOrDefault(x => x.Id == id);
            context.Customers.Remove(entity);
        }
        public Customer GetById(int id) => context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }
}
