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
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Credit>().HasKey(x => new { x.BankId, x.ClientId });

            //modelBuilder.Entity<Credit>()
            //    .HasOne(m => m.Bank)
            //    .WithMany(ma => ma.Credits)
            //    .HasForeignKey(m => m.BankId);

            //modelBuilder.Entity<Credit>()
            //    .HasOne(m => m.Client)
            //    .WithMany(ma => ma.Credits)
            //    .HasForeignKey(a => a.ClientId);
        }

        //entities
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Credit> Credits { get; set; }
    }
}
