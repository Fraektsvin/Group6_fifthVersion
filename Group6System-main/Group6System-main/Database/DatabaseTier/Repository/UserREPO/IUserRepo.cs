using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.UserREPO
{
    public interface IUserRepo
    {
        Task<User> ValidateUserAsync(User user);
    }
}