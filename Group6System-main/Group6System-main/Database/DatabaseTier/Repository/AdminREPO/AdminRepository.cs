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
            try
            {
                await using CloudContext context = new CloudContext();
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
                     return await context.CustomersTable.
                         Include(a=> a.Address).ThenInclude(a=> a.City).ToListAsync();
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
    }
}