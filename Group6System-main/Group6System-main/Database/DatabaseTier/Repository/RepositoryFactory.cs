using DatabaseTier.Repository.AdminREPO;
using DatabaseTier.Repository.CustomerREPO;
using DatabaseTier.Repository.TransactionREPO;
using DatabaseTier.Repository.UserREPO;

namespace DatabaseTier.Repository
{
    public static class RepositoryFactory
    {
        public static IUserRepo GetUserRepository()
        {
            return new UserRepository();
        }

        public static ICustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        public static IAdminRepository GetAdminRepository()
        {
            return new AdminRepository();
        }

        public static ITransactionRepository GetTransactionRepository()
        {
            return new TransactionRepository();
        }
    }
}