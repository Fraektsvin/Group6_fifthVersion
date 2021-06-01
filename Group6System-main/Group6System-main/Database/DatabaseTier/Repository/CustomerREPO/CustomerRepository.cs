using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository.CustomerREPO
{
    public class CustomerRepository:ICustomerRepository
    {
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await using CloudContext context = new CloudContext();
            {
                try
                {
                    var checkingCity = await context.CityTable.FirstOrDefaultAsync(t=> t.ZipCode == customer.Address.City.ZipCode);
                    if (checkingCity != null)
                    {
                        customer.Address.City = checkingCity;
                    }
                    var newAddedCustomer = await context.CustomersTable.AddAsync(customer);
                    await context.SaveChangesAsync();
                    return newAddedCustomer.Entity;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<Customer> GetCustomerAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).FirstOrDefaultAsync(c => c.User.Username.Equals(username));
                if (customer != null)
                {
                    return customer;
                }

                throw new Exception("Customer not found!");
            }
        }
        
        public async Task<Customer> GetCustomerAsync(long cprNumber)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).Include(a=>a.User).FirstOrDefaultAsync(c => c.CprNumber == cprNumber);
                if (customer != null)
                {
                    return customer;
                }

                throw new Exception("Customer not found!");
            }
        }
        
        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                Customer customerToUpdate = await context.CustomersTable.FirstAsync(c=> c.CprNumber == customer.CprNumber);
                context.Update(customerToUpdate);
                await context.SaveChangesAsync();
                return customerToUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"User not found!");
            }
        }
    }
}