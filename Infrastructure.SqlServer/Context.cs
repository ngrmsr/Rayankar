using Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlServer
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
                .IsUnique();
        }
    }
}
