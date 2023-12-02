using Application.Customers.CommandHandler;
using Application.Customers.Query;
using Domain.Customers.Commands;
using Domain.Customers.Contracts;
using Framework.Command;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Contracts;
using Infrastructure.SqlServer;
using Infrastucture.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IOC
{
    public static class Modules
    {
        public static void Register(this IServiceCollection services)
        {

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerEventRepository, CustomerEventRepository>();

            services.AddScoped<ICommandHandler<CustomerCreateCommand>, CustomerCreateHandler>();
            services.AddScoped<ICommandHandler<CustomerUpdateCommand>, CustomerUpdateHandler>();
            services.AddScoped<ICommandHandler<CustomerDeleteCommand>, CustomerDeleteHandler>();

            services.AddScoped<ICustomerQuery, CustomerQueryServices>();
            services.AddSingleton<IDapperContext, DapperContext>();

        }

        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<Context>(opt => opt.UseSqlServer("Server=.;Database=RayankarDB;Trusted_Connection=True;"));
        }
    }
}
