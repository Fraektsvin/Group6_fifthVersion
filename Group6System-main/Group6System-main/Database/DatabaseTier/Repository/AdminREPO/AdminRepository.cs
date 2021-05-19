using System;
using System.Collections.Generic;
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
                Console.WriteLine("Repository " + toValidate);
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
                    Console.WriteLine(customers);
                    return customers;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task RemoveCustomerAsync(int cprNumber)
        {
            await using CloudContext context = new CloudContext();
            Customer customerToRemove = await context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprNumber);
            if (customerToRemove != null)
            {
                context.CustomersTable.Remove(customerToRemove);
                await context.SaveChangesAsync();
            }
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
                Account lastAccount = await context.AccountTable.LastAsync();
                long lastAccountNumber = 1001000000;
                if (lastAccount != null)
                {
                    lastAccountNumber = lastAccount.AccountNumber;
                }
                return lastAccount.AccountNumber;
            }
        }
    }
}