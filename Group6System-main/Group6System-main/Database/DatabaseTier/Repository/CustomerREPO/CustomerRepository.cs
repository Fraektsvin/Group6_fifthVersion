using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using DatabaseTier.Repository.CustomerREPO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CloudContext _context;

        public CustomerRepository()
        {
            _context = new CloudContext(); 
        }
        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.CustomersTable.ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                var newAddedCustomer = await _context.CustomersTable.AddAsync(customer);
                await _context.SaveChangesAsync();
                return newAddedCustomer.Entity;
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task RemoveCustomerAsync(int cprNumber)
        {
            Customer customerToRemove = await _context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprNumber);
            if (customerToRemove != null)
            {
                _context.CustomersTable.Remove(customerToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                Customer customerToUpdate = await _context.CustomersTable.FirstAsync(c=> c.CprNumber == customer.CprNumber);
                _context.Update(customerToUpdate);
                await _context.SaveChangesAsync();
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