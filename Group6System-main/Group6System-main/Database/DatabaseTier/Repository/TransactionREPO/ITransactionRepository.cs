using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.TransactionREPO
{
    public interface ITransactionRepository
    {
        Task<Transaction> TransferMoneyAsync(Transaction transaction);
        Task<Account> GetCustomerAccountAsync(string username);
    }
}