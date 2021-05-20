using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;

namespace DatabaseTier.Repository.TransactionREPO
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> TransferMoneyAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();                         //cast long to object 
            IQueryable<Account> transfer = context.AccountTable.Where(a => a.AccountNumber.Equals(transaction.Receiver));
            Account transferAccount = transfer.FirstOrDefault();

            if (transferAccount.AccountNumber.Equals(transaction.Sender))
            {
                transferAccount.Balance -= transaction.Amount;
            }
            else if (transferAccount.AccountNumber.Equals(transaction.Receiver))
            {
                transferAccount.Balance += transaction.Amount;
            }
            else return null; 
            


            // var updatedBalance = receiverAccount.Balance + transaction.Amount;
            //
            // IQueryable<Account> sender = context.AccountTable.Where(a => a.AccountNumber.Equals(transaction.Sender));
            // Account senderAccount = sender.FirstOrDefault();
            // var updateSenderBalance = senderAccount.Balance - transaction.Amount;
            throw new System.NotImplementedException();
        }
        
        public async Task<Transaction> PayBillAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            throw new System.NotImplementedException();
        }

        public async Task<double> CheckBalanceAsync(Customer customer)
        {
            await using CloudContext context = new CloudContext();
            var customerBalance = context.AccountTable.FirstOrDefault(a => a.Balance == customer.CprNumber);
            if (customerBalance != null)
                return customerBalance.Balance;
            return 0;
        }

        public async Task<Account> GetAccountNumberAsync(Account account)
        {
            await using CloudContext context = new CloudContext();
            var customerAccount = context.AccountTable.FirstOrDefault(a => a.AccountNumber == a.Customer.CprNumber);
            if (customerAccount != null)
                return customerAccount;
            return null;
        }
    }
}