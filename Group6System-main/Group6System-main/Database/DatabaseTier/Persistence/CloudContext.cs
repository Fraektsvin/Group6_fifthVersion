using DatabaseTier.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTier.Persistence
{
    public class CloudContext:DbContext
    {
        public virtual DbSet<User> UsersTable { get; set; }
        public virtual DbSet<Customer> CustomersTable { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = hattie.db.elephantsql.com; Port = 5432; Database = qjqcxidp; Username = qjqcxidp; Password = U2Tl52Z6pKPT4yr9THTkmLDkmCEwB02u",
                options => options.UseAdminDatabase("qjqcxidp"));
        }
    }
}