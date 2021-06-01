using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.CustomerService
{
    public interface ICustomerService
    {
        Task<string> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
//2412962418

        Task<Account> GetAccount(string username);
    }
}