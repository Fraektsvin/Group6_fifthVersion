using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.CustomerService
{
    public interface ICustomerService
    {
        Task<String> AddCustomerAsync(Customer customer);
        Task RemoveCustomerAsync(int cprNumber);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
    }
}