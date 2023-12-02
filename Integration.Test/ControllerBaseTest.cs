using Infrastructure.SqlServer;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Integration.Test
{
    public abstract class ControllerBaseTest
    {
        public readonly HttpClient httpClient;
        private const string connectionString = "Server=.;Database=RayankarDB;Trusted_Connection=True;";
        private readonly IServiceProvider serviceProvider;
        public ControllerBaseTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(b =>
            {
                b.ConfigureServices(services =>
                {
                    var description = services.Single(d => d.ServiceType == typeof(DbContextOptions<Context>));
                    services.Remove(description);
                    services.AddDbContext<Context>
                    (opt => opt.UseSqlServer(connectionString));
                });
            });
            serviceProvider = webAppFactory.Services;
            httpClient = webAppFactory.CreateClient();
        }
        public Context GetContext() =>
            serviceProvider.CreateScope().ServiceProvider.GetRequiredService<Context>();

        protected void StartDatabase()
        {
            GetContext().Database.Migrate();
        }

        protected void ResetDatabase()
        {
            var simpleContext = GetContext();
            simpleContext.Database.ExecuteSqlRaw("Delete Customer");

        }

        protected virtual void SeedData(params object[] data)
        {
            var ctx = GetContext();
            ctx.AddRange(data);
            ctx.SaveChanges();
        }
    }
}
