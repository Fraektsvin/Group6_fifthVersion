using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseTier.Repository.AdminREPO
{
    public class AdminRepository:IAdminRepository
    {
        public async Task<Customer> ValidateCustomerAsync(Customer customer)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                Customer toValidate = await context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).Include(a=> a.User).FirstAsync(c => c.CprNumber == customer.CprNumber);
                toValidate.IsValid = true;
                await context.SaveChangesAsync();
                return toValidate;
            }
            catch (Exception e)
            {
                throw new Exception($"Customer not found!");
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            await using CloudContext context = new CloudContext();
            {
                try
                {
                    IEnumerable<Customer> customers = await context.CustomersTable.Include(a=> a.Address).
                        ThenInclude(a=> a.City).Include(a=> a.User).ToListAsync();
                   return customers;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<string> RemoveCustomerAsync(long cprNumber)
        {
            await using CloudContext context = new CloudContext();

            try
            {
                var customerToRemove = await context.CustomersTable.Include(a=> a.Address).
                    ThenInclude(a=> a.City).Include(a=> a.User).FirstOrDefaultAsync(a=> a.CprNumber == cprNumber);
                context.CustomersTable.Remove(customerToRemove);
              await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception(e.Message);
            }

            return "Successfully removed!"; 
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                var checkUser = await context.UsersTable.FirstOrDefaultAsync(t=> t.Username.Equals(account.User.Username));
                if (checkUser != null)
                {
                    account.User = checkUser;
                }
                EntityEntry<Account> newAccount = await context.AccountTable.AddAsync(account);
                await context.SaveChangesAsync();
                return newAccount.Entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<long> GetLastAccountNumberAsync()
        {
            using(CloudContext context = new CloudContext())
            {
                IQueryable<Account> accounts = context.AccountTable.OrderByDescending(a => a.AccountNumber).
                    Take(1);
                Account lastAccount = accounts.FirstOrDefault();
                long lastAccountNumber = 1001000000;
                if (lastAccount != null)
                {
                    lastAccountNumber = lastAccount.AccountNumber;
                }
                return lastAccountNumber;
            }
        }

        public async Task<User> CheckUserAsync(string username)
        {
            using (CloudContext context = new CloudContext())
            {
                IQueryable<User> users = context.UsersTable.Where(a => a.Username.Equals(username));
                    foreach (User user in users)
                    {
                        if (user.Username.Equals(username))
                        {
                            return user;
                        }
                    }

                    throw new Exception("user not found");
            }
        }
    }
}