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
        Task<Customer> GetCustomer(String username);
        Task<Customer> GetCustomer(int cprNumber);
    }
}