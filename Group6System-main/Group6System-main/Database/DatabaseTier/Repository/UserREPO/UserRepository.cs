using System;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository.UserREPO
{
    public class UserRepository:IUserRepo
    {
        public async Task<User> ValidateUserAsync(User user)
        {
            await using CloudContext context = new CloudContext();
            User validateUser = await context.UsersTable.FirstOrDefaultAsync(u =>
                u.Username.Equals(user.Username));
            if (validateUser != null)
            {
                if (validateUser.Password.Equals(user.Password))
                {
                    return validateUser;
                }
                throw new Exception("Incorrect password!");
            }
            throw new Exception("User not found!");
        }
    }
}