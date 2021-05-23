using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.CustomerService
{
    public interface ICustomerService
    {
        Task<String> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);

        Task<Account> GetAccount(string username);
    }
}