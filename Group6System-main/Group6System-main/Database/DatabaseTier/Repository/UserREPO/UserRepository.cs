using System;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository.UserREPO
{
    public class UserRepository:IUserRepo
    {
        public async Task<User> ValidateUserAsync(User user)
        {
            await using CloudContext context = new CloudContext();
            User validateUser = await context.UsersTable.FirstOrDefaultAsync(u =>
                u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
            if (validateUser != null)
            {
                Console.WriteLine("step 2 --> from the socket to the repo" + validateUser);
                return validateUser;
            }

            throw new Exception("Invalid Input!!");
        }
    }
}