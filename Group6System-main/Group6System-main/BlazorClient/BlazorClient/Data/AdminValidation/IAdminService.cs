using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.AdminValidation
{
    public interface IAdminService
    {
        Task ValidateCustomerAsync(Customer customer);
        Task RemoveCustomerAsync(int cprNumber);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task<String> CreateAccountAsync(string username);
    }
}