using Microsoft.EntityFrameworkCore;
using Befirst.DataAccess.Models;

namespace Befirst.DataAccess.DbConnection
{
    public class BefirstDbContext : DbContext
    {
        public BefirstDbContext(DbContextOptions<BefirstDbContext> options) :
            base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<WorkInRegions> WorksInRegions { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}