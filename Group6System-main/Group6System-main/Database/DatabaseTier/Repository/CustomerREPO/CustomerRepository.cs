using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository.CustomerREPO
{
    public class CustomerRepository:ICustomerRepository
    {
        public async Task<IList<Customer>> GetAllAsync()
        {
            await using CloudContext context = new CloudContext();
            return await context.CustomersTable.ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            using (CloudContext context = new CloudContext())
            {
                try
                {
                    var checkingCity = await context.CityTable.FirstOrDefaultAsync(t=> t.ZipCode == customer.Address.City.ZipCode);
                    if (checkingCity != null)
                    {
                        customer.Address.City = checkingCity;
                    }
                    var newAddedCustomer = await context.CustomersTable.AddAsync(customer);
                    Console.WriteLine("customer repo " + newAddedCustomer);
                    await context.SaveChangesAsync();
                    return newAddedCustomer.Entity;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<Customer> GetCustomer(string username)
        {
            using (CloudContext context = new CloudContext())
            {
                //var customer = await context.CustomersTable.FirstOrDefaultAsync(c => c.User.Username.Equals(username));
                Customer customer = context.CustomersTable.FirstOrDefault(c => c.User.Username.Equals(username));
                if (customer != null)
                {
                    Console.WriteLine(customer);
                    return customer;
                }

                throw new Exception("Customer not found!");
            }
        }

        public async Task<Customer> GetCustomer(int cprnumber)
        {
            using (CloudContext context = new CloudContext())
            {
                //var customer = context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprnumber);
                Customer customer = context.CustomersTable.FirstOrDefault(c => c.CprNumber == cprnumber);
                if (customer != null)
                {
                    Console.WriteLine(customer);
                    return customer;
                }

                throw new Exception("Customer not found!");
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
                Console.WriteLine(e.StackTrace);
                throw new Exception($"User not found!");
            }
        }
    }
}