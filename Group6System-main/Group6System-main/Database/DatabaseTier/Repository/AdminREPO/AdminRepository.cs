using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

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
                    IEnumerable<Customer> customers = await context.CustomersTable.
                        Include(a=> a.Address).ThenInclude(a=> a.City).ToListAsync();
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
            Customer customerToRemove = await context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprNumber);
            Console.WriteLine(customerToRemove);
            context.CustomersTable.Remove(customerToRemove);
            await context.SaveChangesAsync();

            return "Successfully removed!"; 
        }

        public async Task<string> CreateAccountAsync(Account account)
        {
            using (CloudContext context = new CloudContext())
            {
                try
                {
                    await context.AccountTable.AddAsync(account);
                    return "Successful";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public async Task<long> GetLastAccountNumberAsync()
        {
            using(CloudContext context = new CloudContext())
            {
                IQueryable<Account> Accounts = context.AccountTable.OrderByDescending(a => a.AccountNumber).Take(1);
                Account lastAccount = Accounts.FirstOrDefault();
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