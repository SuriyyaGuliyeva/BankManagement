using BankManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Context
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //entities
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Credit> Credits { get; set; }
    }
}
