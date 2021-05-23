using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.UserService
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
         Task<User> GetUser(string username, string password);
    }
}