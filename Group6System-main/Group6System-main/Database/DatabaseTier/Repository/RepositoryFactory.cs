using System.Runtime.InteropServices;
using DatabaseTier.Repository.CustomerREPO;
using DatabaseTier.Repository.UserREPO;

namespace DatabaseTier.Repository
{
    public class RepositoryFactory
    {
        public static IUserRepo GetUserRepository()
        {
            return new UserRepository();
        }

        public static ICustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}