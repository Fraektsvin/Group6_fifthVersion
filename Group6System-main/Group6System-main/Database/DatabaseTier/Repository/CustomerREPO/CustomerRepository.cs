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

        public async Task<Customer> GetCustomerAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            {
                //var customer = await context.CustomersTable.FirstOrDefaultAsync(c => c.User.Username.Equals(username));
                Customer customer = context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).FirstOrDefault(c => c.User.Username.Equals(username));
                if (customer != null)
                {
                    Console.WriteLine(customer);
                    return customer;
                }

                throw new Exception("Customer not found!");
            }
        }

        public async Task<Account> GetCustomerAccountAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            {
                // Console.WriteLine(username + "getaccount");
                // Customer customer =
                //         context.CustomersTable.Include(c => c.User).FirstOrDefault(a => a.User.Username.Equals(username));
                // Console.WriteLine(customer.CprNumber + " getaccount");
                // Account customerAccount =  
                //      context.AccountTable.Include(c => c.Customer).FirstOrDefault(a => a.Customer.CprNumber == customer.CprNumber);
                // Console.WriteLine(customerAccount.AccountNumber);
                // if(customerAccount != null)
                //     return customerAccount;
                //
                // throw new Exception("Account Not found.");
                Customer customer = await GetCustomerAsync(username);
                
                Account account = await context.AccountTable
                    .FirstOrDefaultAsync(c => c.Customer.Equals(customer));
                Console.WriteLine(account.ToString());

                if (account != null)
                {
                    return account;
                }
                throw new Exception("Account not found!!");
            }
        }

        public async Task<Customer> GetCustomerAsync(int cprNumber)
        {
            await using CloudContext context = new CloudContext();
            {
                //var customer = context.CustomersTable.FirstOrDefaultAsync(c => c.CprNumber == cprnumber);
                Customer customer = context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).FirstOrDefault(c => c.CprNumber == cprNumber);
                if (customer != null)
                {
                    Console.WriteLine(customer);
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
                Console.WriteLine(e.StackTrace);
                throw new Exception($"User not found!");
            }
        }
    }
}