using DatabaseTier.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTier.Persistence
{
    public class CloudContext:DbContext
    {
        public virtual DbSet<User> UsersTable { get; set; }
        public virtual DbSet<City> CityTable { get; set; }
        public virtual DbSet<Address> AddressTable { get; set;}
        public virtual DbSet<Account> AccountTable { get; set; }
        public virtual DbSet<SavedAccounts> SavedAccountsTable { get; set; }
        public virtual DbSet<Customer> CustomersTable { get; set; }
        public virtual DbSet<Transaction> TransactionTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = hattie.db.elephantsql.com; Port = 5432; Database = qjqcxidp; Username = qjqcxidp; Password = U2Tl52Z6pKPT4yr9THTkmLDkmCEwB02u",
                options => options.UseAdminDatabase("qjqcxidp"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasOne(a => a.City);
            modelBuilder.Entity<Customer>().HasOne(a => a.Address);
            modelBuilder.Entity<Customer>().HasOne(c => c.User);

        }
    }
}