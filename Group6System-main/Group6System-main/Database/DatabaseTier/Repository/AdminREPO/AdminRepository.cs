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
                    ThenInclude(c=> c.City).FirstAsync(c => c.CprNumber == customer.CprNumber);
                toValidate.IsValid = true;
                await context.SaveChangesAsync();
                return toValidate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"Customer not found!");
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            await using CloudContext context = new CloudContext();
            {
                try
                {
                    var customers = await context.CustomersTable.Include(a=> a.Address).
                        ThenInclude(a=> a.City).Include(a=> a.User).ToListAsync();
                   return customers;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<string> RemoveCustomerAsync(int cprNumber)
        {
            await using CloudContext context = new CloudContext();

            try
            {
                IQueryable<Customer> customerToRemove = context.CustomersTable.Include(a=> a.Address).
                    ThenInclude(a=> a.City).Include(a=> a.User);
                
                var toRemove = context.CustomersTable.FirstOrDefault(c => c.CprNumber == cprNumber);
                context.CustomersTable.Remove(toRemove);
                context.AddressTable.Remove(toRemove.Address);
                context.CityTable.Remove(toRemove.Address.City);
                context.UsersTable.Remove(toRemove.User);
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
            {
                try
                {
                    var checkCustomer = await context.CustomersTable.FirstOrDefaultAsync(t=> t.CprNumber == account.Customer.CprNumber);
                    if (checkCustomer != null)
                    {
                        account.Customer = checkCustomer;
                    }
                    EntityEntry<Account> newAccount = await context.AccountTable.AddAsync(account);
                    await context.SaveChangesAsync();
                    return newAccount.Entity;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    throw new Exception(e.Message);
                }
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
                Console.WriteLine(lastAccountNumber);
                return lastAccountNumber;
            }
        }
    }
}