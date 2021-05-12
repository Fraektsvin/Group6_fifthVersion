using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.CustomerREPO
{
    public interface ICustomerRepository 
    {
        Task<IList<Customer>> GetAllAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
        Task RemoveCustomerAsync(int cprNumber);
        Task<Customer> UpdateCustomerAsync(Customer customer);
    }
}