using System.Collections.Generic;
using CustomersApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
