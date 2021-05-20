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
            modelBuilder.Entity<Address>().HasOne(a => a.City);
            modelBuilder.Entity<Customer>().HasOne(a => a.Address);
            modelBuilder.Entity<Customer>().HasOne(c => c.User);
            modelBuilder.Entity<User>().HasKey(a => a.Username);
            modelBuilder.Entity<Customer>().HasKey(a => a.CprNumber);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<City>().HasKey(a => a.ZipCode);
            /*
            modelBuilder.Entity<Address>(cus =>
            {
                cus.OwnsOne(a => a.City,
                    add =>
                    {
                        add.Property(c => c.CityName).IsRequired();
                        add.Property(c => c.ZipCode).IsRequired();
                    });
            });
            
            modelBuilder.Entity<Customer>(cus =>
            {
                cus.OwnsOne(a => a.Address,
                    add =>
                    {
                        add.Property(c => c.StreetName).IsRequired();
                        add.Property(c => c.StreetNumber).IsRequired();
                    });
            });*/
        }
    }
}