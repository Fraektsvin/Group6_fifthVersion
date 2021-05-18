using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.AdminValidation
{
    public interface IAdminService
    {
        Task ValidateCustomerAsync(Customer customer);
        Task CreateCustomerAccountAsync(Customer customer, Account account);
    }
}