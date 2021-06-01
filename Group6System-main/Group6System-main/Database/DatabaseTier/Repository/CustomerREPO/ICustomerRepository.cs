using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.CustomerREPO
{
    public interface ICustomerRepository 
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(string username);
        //Task<Account> GetCustomerAccountAsync(string username);
        Task<Customer> GetCustomerAsync(long cprNumber);
    }
}