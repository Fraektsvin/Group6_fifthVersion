using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.AccountService
{
    public interface IAccount
    {
         Task AddAccount(Account account);

    }
}