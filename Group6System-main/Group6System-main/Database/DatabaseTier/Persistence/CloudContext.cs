using DatabaseTier.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTier.Persistence
{
    public class CloudContext:DbContext
    {
        public DbSet<User> UsersTable { get; set; }
        public DbSet<City> CityTable { get; set; }
        public DbSet<Address> AddressTable { get; set;}
        public DbSet<Account> AccountTable { get; set; }
        public DbSet<SavedAccounts> SavedAccountsTable { get; set; }
        public DbSet<Customer> CustomersTable { get; set; }
        public DbSet<Transaction> TransactionTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = hattie.db.elephantsql.com; Port = 5432; Database = qjqcxidp; Username = qjqcxidp; Password = U2Tl52Z6pKPT4yr9THTkmLDkmCEwB02u",
                options => options.UseAdminDatabase("qjqcxidp"));
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(c => new { c.StreetName, c.StreetNumber });
        }
    }
}